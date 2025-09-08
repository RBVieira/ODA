using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Domain.Entities
{
    [Table("ExternalIdentifiers")]
    public class ExternalIdentifier
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
        // O valor do ID no sistema externo. Ex: "TICKET-12345"
        public string? ExternalIdValue { get; set; }

        // O tipo do identificador. Ex: "TicketNumber"
        public string? ExternalIdType { get; set; }

        // O nome do sistema dono do ID. Ex: "ServiceNow"
        public string? Owner { get; set; }

        // --- Chave Estrangeira ---
        public string PartyInteractionId { get; set; }

        [JsonIgnore]
        public PartyInteraction PartyInteraction { get; set; }
    }
}