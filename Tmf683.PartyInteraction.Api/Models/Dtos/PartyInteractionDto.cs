using System.ComponentModel.DataAnnotations;

namespace Tmf683.PartyInteraction.Api.Models.Dtos
{
    public class PartyInteractionDto
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string InteractionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string Channel { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<RelatedPartyRefDto> RelatedParty { get; set; }
        
        // ✅ Nova propriedade para remoção explícita
        public List<string> RelatedPartyToRemove { get; set; }

        public DateTime? LastUpdateDate { get; set; }

    }
}
