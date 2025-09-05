using AutoMapper;
using Tmf683.PartyInteraction.Api.Models.Dtos;
using Tmf683.PartyInteraction.Api.Models.Entities;

namespace Tmf683.PartyInteraction.Api.Mappings
{
    public class AutoMapperProfile : Profile // Inherit from AutoMapper's Profile class  
    {
        public AutoMapperProfile() // Constructor to define mappings  
        {
            CreateMap<PartyInteract, PartyInteractionDto>().ReverseMap();
            CreateMap<RelatedPartyRef, RelatedPartyRefDto>().ReverseMap();
        }
    }
}
