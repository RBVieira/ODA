using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models
{
    // Classe para relacionamentos com outras entidades ou partes
    public class RelatedParty
    {
        [Key]
        [ValidateNever]
        public string Id { get; set; }
        public string PartyId { get; set; }
        public string Role { get; set; }
        public string RelationshipType { get; set; }
        [ValidateNever]
        public string IndividualId { get; set; }

        // Construtor

    }
}
