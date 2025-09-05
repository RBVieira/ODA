using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Tmf683.PartyInteraction.Api.Models
{
    public class RelatedPartyRef
    {
        [Key]
        [ValidateNever]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PartyId { get; set; } = string.Empty; // O ID do Individual ou Organization da TMF632
        public string Role { get; set; } = string.Empty;

        [ValidateNever]
        public string PartyInteractionId { get; set; }
    }
}
