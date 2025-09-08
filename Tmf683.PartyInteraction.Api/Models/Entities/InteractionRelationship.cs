using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Entities
{
    [Table("InteractionRelationships")]
    public class InteractionRelationship
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
        public string? Href { get; set; } // Link para a interação relacionada
        public string? Name { get; set; } // Nome descritivo do relacionamento
        public string? RelationshipType { get; set; } // Ex: "follows"

        // O ID da outra PartyInteraction que está sendo referenciada.
        public string? TargetInteractionId { get; set; }

        // --- Chave Estrangeira ---
        public string PartyInteractionId { get; set; }

        [JsonIgnore]
        public PartyInteraction PartyInteraction { get; set; }
    }
}