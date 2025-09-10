using AutoMapper;
using Microsoft.Extensions.Options;
using System.Net;
using Tmf683.PartyInteraction.Application.Models.APIs;
using Tmf683.PartyInteraction.Application.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Application.Models.Dtos.Responses;
using Tmf683.PartyInteraction.Application.Services.Interfaces;



namespace Tmf683.PartyInteraction.Application.Services
{
    public class PartyInteractionService : IPartyInteractionService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Tmf632ApiConfiguration _tmf632Config;

        public PartyInteractionService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpClientFactory httpClientFactory,
            IOptions<Tmf632ApiConfiguration> tmf632Config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _tmf632Config = tmf632Config.Value;
        }

        public async Task<IEnumerable<PartyInteractionResponseDto>> GetAllAsync()
        {
            var interactions = await _unitOfWork.PartyInteractions.GetAllAsync();
            return _mapper.Map<IEnumerable<PartyInteractionResponseDto>>(interactions);
        }

        public async Task<PartyInteractionResponseDto?> GetByIdAsync(string id)
        {
            var interaction = await _unitOfWork.PartyInteractions.GetByIdAsync(id);
            return _mapper.Map<PartyInteractionResponseDto>(interaction);
        }

        public async Task<(Domain.Entities.PartyInteraction? CreatedInteraction, string? ErrorMessage)> CreateAsync(PartyInteractionCreateDto createDto)
        {
            // 1. Orquestração: Validar se as Partes Relacionadas existem na API TMF632
            var client = _httpClientFactory.CreateClient("PartyManagementClient");

            foreach (var partyRefDto in createDto.RelatedParty)
            {
                var endpointUrl = $"{_tmf632Config.BaseUrl}{_tmf632Config.GetIndividualEndpoint}{partyRefDto.Id}";
                
                var response = await client.GetAsync(endpointUrl);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, $"PartyId '{partyRefDto.Id}' não encontrado na API externa.");
                }
            }

            // 2. Mapeamento e Lógica de Negócio
            var newInteraction = _mapper.Map<Domain.Entities.PartyInteraction>(createDto);

            newInteraction.Id = Guid.NewGuid().ToString(); // Gerado pelo servidor
            newInteraction.CreationDate = DateTime.UtcNow;
            newInteraction.LastUpdateDate = DateTime.UtcNow;
            newInteraction.Status = "open"; // Status inicial padrão
            newInteraction.BaseType = "PartyInteraction";
            newInteraction.Type = "PartyInteraction"; // Pode ser mais específico se necessário

            // 3. Persistência via Unit of Work
            await _unitOfWork.PartyInteractions.CreateAsync(newInteraction);
            await _unitOfWork.CompleteAsync();

            return (newInteraction, null);
        }

        public async Task<(Domain.Entities.PartyInteraction? UpdatedInteraction, string? ErrorMessage)> UpdateAsync(string id, PartyInteractionUpdateDto updateDto)
        {
            var existingInteraction = await _unitOfWork.PartyInteractions.GetByIdAsync(id);

            if (existingInteraction == null)
            {
                return (null, "Interação não encontrada.");
            }

            // O AutoMapper aplicará apenas as propriedades não nulas do DTO
            _mapper.Map(updateDto, existingInteraction);
            existingInteraction.LastUpdateDate = DateTime.UtcNow;

            _unitOfWork.PartyInteractions.Update(existingInteraction);

            await _unitOfWork.CompleteAsync();

            return (existingInteraction, null);
        }

        public async Task<(bool Success, string? ErrorMessage)> DeleteAsync(string id)
        {
            var interactionToDelete = await _unitOfWork.PartyInteractions.GetByIdAsync(id);

            if (interactionToDelete == null)
            {
                return (false, "Interação não encontrada.");
            }

            _unitOfWork.PartyInteractions.Delete(interactionToDelete);
            await _unitOfWork.CompleteAsync();

            return (true, null);
        }
    }
}