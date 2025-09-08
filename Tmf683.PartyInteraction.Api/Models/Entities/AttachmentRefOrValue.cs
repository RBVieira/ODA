using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Entities
{
    [Table("Attachments")]
    public class AttachmentRefOrValue
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // --- Atributos de Metadados TMF ---
        [Column("@baseType")]
        public string? BaseType { get; set; }

        [Column("@type")]
        public string? Type { get; set; } // Discriminador: "Attachment" ou "AttachmentRef"

        [Column("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        [Column("@referredType")]
        public string? ReferredType { get; set; }

        // --- Atributos de Negócio Comuns ---
        public string? Href { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        // --- Atributos para Attachment (Value) ---
        public string? Content { get; set; }
        public string? MimeType { get; set; }
        public long? Size { get; set; }
        public DateTime? ValidForStart { get; set; }
        public DateTime? ValidForEnd { get; set; }

        // --- Chave Estrangeira ---
        public string PartyInteractionId { get; set; }

        [JsonIgnore]
        public PartyInteraction PartyInteraction { get; set; }

        // --- Chave Estrangeira para o Item PAI (Opcional) ---
        // Nova chave estrangeira para se relacionar com um InteractionItem.
        public string? InteractionItemId { get; set; }

        [JsonIgnore]
        public InteractionItem? InteractionItem { get; set; }
    }
}
