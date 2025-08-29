using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models
{
    // Classe para relacionamentos com outras entidades ou partes
    public class RelatedParty
    {
        [Key]
        public Guid Id { get; set; }
        public string PartyId { get; set; }
        public string Role { get; set; }
        public string RelationshipType { get; set; }
        public string IndividualId { get; set; }

        // Construtor
        public RelatedParty()
        {
            Id = Guid.NewGuid();
        }
    }
}
