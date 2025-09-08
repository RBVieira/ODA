using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Entities
{
    [Table("RelatedParties")]
    public class RelatedPartyOrPartyRole
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

        // Discriminador que indica se a referência é para 'Party' ou 'PartyRole'.
        [Column("@referredType")]
        public string? ReferredType { get; set; }

        // --- Atributos de Negócio ---
        public string? Href { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; } // O papel nesta interação específica.

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
