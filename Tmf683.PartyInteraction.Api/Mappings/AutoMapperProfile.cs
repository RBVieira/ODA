using AutoMapper;
using Tmf683.PartyInteraction.Api.Models.Dtos;
using Tmf683.PartyInteraction.Api.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Api.Models.Dtos.Responses;
using Tmf683.PartyInteraction.Api.Models.Entities;

namespace Tmf683.PartyInteraction.Api.Mappings
{
    /// <summary>
    /// Define todos os mapeamentos entre as Entidades de domínio e os Data Transfer Objects (DTOs).
    /// Esta é a fonte única da verdade para a lógica de conversão de objetos.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // --- Mapeamentos para o Recurso Principal: PartyInteraction ---

            // Para Respostas (GET): Mapeamento completo da Entidade para o DTO de resposta.
            CreateMap<Models.Entities.PartyInteraction, PartyInteractionResponseDto>();

            // Para Criação (POST): Mapeamento do DTO de criação para a Entidade.
            CreateMap<PartyInteractionCreateDto, Models.Entities.PartyInteraction>();

            // Para Atualização (PATCH): Mapeamento do DTO de atualização para a Entidade.
            CreateMap<PartyInteractionUpdateDto, Models.Entities.PartyInteraction>()
                // Ignora listas nulas no DTO para não apagar dados existentes na entidade.
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // --- Mapeamentos para Entidades Aninhadas e Auxiliares ---

            // Mapeamentos bidirecionais (.ReverseMap()) para entidades com estruturas semelhantes.
            CreateMap<RelatedPartyOrPartyRole, RelatedPartyOrPartyRoleDto>().ReverseMap();
            CreateMap<InteractionItem, InteractionItemDto>().ReverseMap();
            CreateMap<ExternalIdentifier, ExternalIdentifierDto>().ReverseMap();
            CreateMap<InteractionRelationship, InteractionRelationshipDto>().ReverseMap();
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<RelatedChannel, RelatedChannelDto>().ReverseMap();

            // Mapeamento customizado para AttachmentRefOrValue devido à estrutura TimePeriod
            CreateMap<AttachmentRefOrValue, AttachmentRefOrValueDto>()
                .ForMember(dest => dest.ValidFor,
                           opt => opt.MapFrom(src =>
                               (src.ValidForStart.HasValue || src.ValidForEnd.HasValue)
                               ? new TimePeriodDto { StartDateTime = src.ValidForStart, EndDateTime = src.ValidForEnd }
                               : null));

            CreateMap<AttachmentRefOrValueDto, AttachmentRefOrValue>()
                .ForMember(dest => dest.ValidForStart,
                           opt => opt.MapFrom(src => src.ValidFor != null ? src.ValidFor.StartDateTime : (DateTime?)null))
                .ForMember(dest => dest.ValidForEnd,
                           opt => opt.MapFrom(src => src.ValidFor != null ? src.ValidFor.EndDateTime : (DateTime?)null));

            // Mapeamento para o DTO auxiliar TimePeriod
            //CreateMap<TimePeriodDto, TimePeriod>().ReverseMap(); // Supondo que você tenha uma entidade TimePeriod se precisar
        }
    }
}
