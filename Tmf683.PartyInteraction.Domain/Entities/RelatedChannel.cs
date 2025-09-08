using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Domain.Entities
{
    [Table("RelatedChannels")]
    public class RelatedChannel
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

        [Column("@referredType")]
        public string? ReferredType { get; set; }

        // --- Atributos de Negócio ---
        public string? Href { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; } // Ex: "Canal de Origem"

        // --- Chave Estrangeira ---
        public string PartyInteractionId { get; set; }

        [JsonIgnore]
        public PartyInteraction PartyInteraction { get; set; }
    }
}
