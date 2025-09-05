using AutoMapper;
using Tmf632.PartyManagement.Api.Models;
using Tmf632.PartyManagement.Api.Models.Dtos;

namespace Tmf632.PartyManagement.Api.Mappings
{
    public class MappingProfile : Profile // Inherit from AutoMapper's Profile class
    {
        public MappingProfile() // Constructor to define mappings
        {
            CreateMap<Individual, IndividualDto>().ReverseMap(); // Define mapping between Individual and IndividualDto
            CreateMap<Organization, OrganizationDto>().ReverseMap();


            // Mapeamentos para as entidades aninhadas
            CreateMap<ContactMedium, ContactMediumDto>().ReverseMap();
            CreateMap<RelatedParty, RelatedPartyDto>().ReverseMap();
            CreateMap<Characteristic, CharacteristicDto>().ReverseMap();
        }
    }
}
