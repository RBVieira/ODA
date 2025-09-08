using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Entities
{
    [Table("InteractionItems")]
    public class InteractionItem
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
        public string? ItemType { get; set; } // Ex: "Diagnóstico", "Criação de Ticket"
        public string? Description { get; set; }

        // --- Atributos de Auditoria ---
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        // --- Chave Estrangeira para a Interação PAI ---
        public string PartyInteractionId { get; set; }

        [JsonIgnore]
        public PartyInteraction PartyInteraction { get; set; }

        public List<Note> Note { get; set; } = new();
        public List<AttachmentRefOrValue> Attachment { get; set; } = new();
        public List<RelatedPartyOrPartyRole> RelatedParty { get; set; } = new();


        // --- Relacionamentos do PRÓPRIO Item ---
        // Um item pode ter seus próprios relacionamentos, notas, etc.
        // A implementação completa exigiria que as entidades Note, RelatedChannel, etc.,
        // tivessem uma chave estrangeira para InteractionItem (além da de PartyInteraction).
        // Por simplicidade nesta fase, declaramos as listas. A refatoração do banco
        // para suportar a dupla FK é um passo avançado.
        // public List<InteractionItemRelationship> InteractionItemRelationship { get; set; } = new();
        // public List<Note> Note { get; set; } = new();
        // ... e assim por diante.
    }
}