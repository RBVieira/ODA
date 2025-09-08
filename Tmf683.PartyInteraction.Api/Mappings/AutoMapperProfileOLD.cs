using AutoMapper;
using Tmf683.PartyInteraction.Api.Models.Dtos;
using Tmf683.PartyInteraction.Api.Models.Entities;

namespace Tmf683.PartyInteraction.Api.Mappings
{
    public class AutoMapperProfileOLD : Profile // Inherit from AutoMapper's Profile class  
    {
        public AutoMapperProfileOLD() // Constructor to define mappings  
        {
            CreateMap<Models.Entities.PartyInteraction, PartyInteractionDto>().ReverseMap();
            CreateMap<RelatedPartyRefOLD, RelatedPartyRefDto>().ReverseMap();
        }
    }
}
