using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

//Importante lembrar que nas classes DTOs vc não precisa das propriedades de navegação de retorno como nas classes originais

namespace Tmf632.PartyManagement.Api.Models.Dtos
{
    // Classe para relacionamentos com outras entidades ou partes
    public class RelatedPartyDto
    {
        [Key]
        [ValidateNever]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PartyId { get; set; }
        public string Role { get; set; }
        public string RelationshipType { get; set; }

        // Foreign key for the parent Individual entity
        public string? IndividualId { get; set; }



        // Foreign key for the parent Organization entity
        public string? OrganizationId { get; set; }


    }
}
