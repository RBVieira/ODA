using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Entities
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // --- Atributos de Metadados TMF ---
        [Column("@baseType")]
        public string? BaseType { get; set; }

        [Column("@type")]
        public string? Type { get; set; }

        [Column("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        // --- Atributos de Negócio ---
        public string? Author { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }

        // --- Chave Estrangeira ---
        public string? PartyInteractionId { get; set; }
        [JsonIgnore]
        public PartyInteraction? PartyInteraction { get; set; }

        public string? InteractionItemId { get; set; }
        [JsonIgnore]
        public InteractionItem? InteractionItem { get; set; }
    }
}
