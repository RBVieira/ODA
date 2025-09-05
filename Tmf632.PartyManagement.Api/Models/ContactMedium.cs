using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models
{
    // Classe para informações de contato (ex: email, telefone)
    public class ContactMedium
    {
        [Key]
        [ValidateNever]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string MediumType { get; set; }
        public bool Preferred { get; set; }
        public string Value { get; set; }

        // Foreign key for the parent Individual entity
        public string? IndividualId { get; set; }
        public Individual? Individual { get; set; }

        // Foreign key for the parent Organization entity
        public string? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

    }
    

}
