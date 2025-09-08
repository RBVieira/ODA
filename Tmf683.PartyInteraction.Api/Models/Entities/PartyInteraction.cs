using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tmf683.PartyInteraction.Api.Models.Entities
{
    [Table("PartyInteractions")]
    public class PartyInteraction
    {
        [Key]
        public string Id { get; set; }

        public string? Href { get; set; } // Novo: Link canônico para o recurso.

        // --- Atributos de Metadados TMF ---
        [Column("@baseType")] // Mapeamento para nomes com caracteres especiais
        public string? BaseType { get; set; }

        [Column("@type")]
        public string? Type { get; set; }

        [Column("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        // --- Atributos de Negócio ---
        public string? Description { get; set; }
        public string? Reason { get; set; } // Novo: Motivo da interação.
        public string? Status { get; set; }

        // O "interactionDate" do TMF é um TimePeriod. Modelamos com início e fim.
        public DateTime? InteractionStartDate { get; set; } // Novo
        public DateTime? InteractionEndDate { get; set; }   // Novo

        // --- Atributos de Auditoria ---
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        // --- Relacionamentos (1 para N) ---
        public List<ExternalIdentifier> ExternalIdentifier { get; set; } = new();
        public List<InteractionRelationship> InteractionRelationship { get; set; } = new();
        public List<Note> Note { get; set; } = new();
        public List<InteractionItem> InteractionItem { get; set; } = new();
        public List<RelatedPartyOrPartyRole> RelatedParty { get; set; } = new();
        public List<RelatedChannel> RelatedChannel { get; set; } = new();
        public List<AttachmentRefOrValue> Attachment { get; set; } = new();
    }
}