using System.ComponentModel.DataAnnotations;

namespace Tmf683.PartyInteraction.Api.Models
{
    public class PartyInteract
    {

    [Key]
        public string Id { get; set; } 
        public string InteractionType { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } 
        public string Channel { get; set; } 
        public string Status { get; set; }
        public List<RelatedPartyRef> RelatedParty { get; set; } = new List<RelatedPartyRef>();
        
        public DateTime LastUpdateDate { get; set; }
        
    }
}

