using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tmf683.PartyInteraction.Api.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Api.Models.Dtos.Responses;
using Tmf683.PartyInteraction.Api.Services.Interfaces;
using Tmf683.PartyInteraction.Api.Data;
using Microsoft.EntityFrameworkCore;
using Tmf683.PartyInteraction.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using Tmf683.PartyInteraction.Api.Models.Entities;
using Tmf683.PartyInteraction.Api.Models.Dtos;

namespace Tmf683.PartyInteraction.Api.Services
{
    public class PartyInteractionService : IPartyInteractionService
    {
        #region SETTINGS da Classe
        private readonly IPartyInteractionRepository _repository;
        private readonly IMapper _mapper;

        public PartyInteractionService(IPartyInteractionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion


        //GET ALL Interactions
        public async Task<IEnumerable<PartyInteractionResponseDto>> GetAllPartyInteractionsAsync()
        {
            var interactions = await _repository.GetAllPartyInteractionsAsync();
            return _mapper.Map<IEnumerable<PartyInteractionResponseDto>>(interactions);
        }

        //GET by ID
        public async Task<PartyInteractionResponseDto?> GetPartyInteractionByIdAsync(string id)
        {
            var interaction = await _repository.GetPartyInteractionByIdAsync(id);
            return _mapper.Map<PartyInteractionResponseDto>(interaction);
        }


        //PATCH
        public async Task<IActionResult> PatchPartyInteractionAsync(string id, PartyInteractionUpdateDto dto)
        {
            //Na operação de PATCH o ID não deve vir no corpo e sim na URL  
            if (!string.IsNullOrEmpty(id))
                return new BadRequestObjectResult("O ID na URL deve ser fornecido.");

            //Busca a interação existente no banco de dados mas utiliza o método GetPartyInteractionByIdAsync do repositório
            var existing = await _repository.GetPartyInteractionByIdAsync(id);

            if (existing == null)
                return new NotFoundResult();

            //Aplica os patches nos campos fornecidos no DTO  
            ApplyPatch(existing.Description, dto.Description, val => existing.Description = val);
            ApplyPatch(existing.Status, dto.Status, val => existing.Status = val);
            //ApplyPatch(existing.RelatedChannel, dto.RelatedChannel, val => existing.RelatedChannel = val);

            // Atualiza ou adiciona RelatedParty conforme fornecido no DTO dentro da entidade PartyInteract  
            foreach (var relatedPartyDto in dto.RelatedParty ?? Enumerable.Empty<RelatedPartyOrPartyRoleDto>())
            {

                var existingRelatedParty = existing.RelatedParty.FirstOrDefault(rp => rp.Id == relatedPartyDto.Id);

                if (existingRelatedParty != null)
                {
                    ApplyPatch(existingRelatedParty.Role, relatedPartyDto.Role, val => existingRelatedParty.Role = val);
                    ApplyPatch(existingRelatedParty.Id, relatedPartyDto.Id, val => existingRelatedParty.Id = val);
                }
                else
                {
                    var newRp = _mapper.Map<RelatedPartyOrPartyRole>(relatedPartyDto);
                }
            }



            // Atualiza a data de última modificação  
            existing.LastUpdateDate = DateTime.UtcNow;

            // Valida o modelo atualizado antes de salvar  
            if (!TryValidateModel(existing))
                return new BadRequestObjectResult(new ValidationProblemDetails());

            // Salva as alterações no banco de dados  
            await _repository.SaveChangesAsync();
            return new NoContentResult();
        }

        //PUT/UPDATE
        public async Task<bool> UpdatePartyInteractionAsync(string id, PartyInteractionUpdateDto dto)
        {

            // 1. Validar ID
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("O ID da URL deve ser informado.");

            // 2. Validar campos obrigatórios
            if (!IsComplete(dto, out var missingFields))
                throw new ArgumentException($"Campos obrigatórios ausentes: {string.Join(", ", missingFields)}");

            // 3. Buscar entidade existente
            var existing = await _repository.GetPartyInteractionByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Interação não encontrada.");

            // 4. Mapear DTO para entidade
            var updatedEntity = _mapper.Map<Models.Entities.PartyInteraction>(dto);
            updatedEntity.LastUpdateDate = DateTime.UtcNow;

            // 5. Persistir
            await _repository.UpdatePartyInteractionAsync(updatedEntity);

            return true;

        }




        #region Métodos Auxiliares
        //Método genérico para fazer substituição de valores somente nos campos onde realmente ocorreram alterações
        private void ApplyPatch<T>(T currentValue, T newValue, Action<T> setter, Func<T, T, bool> comparer = null)
        {
            if (newValue != null && !(comparer?.Invoke(currentValue, newValue) ?? newValue.Equals(currentValue)))
                setter(newValue);
        }


        //Método para validar o modelo depois de feitas todas as alterações de inserções e deletes na estrutura da entidade
        //valida os dados contra a estrutura de dados definada no modelo das entidades
        private bool TryValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, validationContext, results, true);
        }

        //Método para validar se todos os campos obrigatórios estão presentes no DTO para a operação de PUT
        private bool IsComplete(PartyInteractionUpdateDto dto, out List<string> missingFields)
        {
            missingFields = new();

            if (string.IsNullOrWhiteSpace(dto.Status)) missingFields.Add("Status");
            //if (string.IsNullOrWhiteSpace(dto.Channel)) missingFields.Add("Channel");
            if (string.IsNullOrWhiteSpace(dto.Description)) missingFields.Add("Description");
            if (dto.RelatedParty == null || !dto.RelatedParty.Any()) missingFields.Add("RelatedParty");

            return !missingFields.Any();
        }


        #endregion
    }
}
