using AutoMapper;
using Tmf683.PartyInteraction.Api.Models;
using Tmf683.PartyInteraction.Api.Models.Dtos;

namespace Tmf683.PartyInteraction.Api.Mappings
{
    public class MappingProfile : Profile // Inherit from AutoMapper's Profile class  
    {
        public MappingProfile() // Constructor to define mappings  
        {
            CreateMap<Models.PartyInteract, PartyInteractionDto>().ReverseMap();
            CreateMap<RelatedPartyRef, RelatedPartyRefDto>().ReverseMap();
        }
    }
}
