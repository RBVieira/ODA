using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Application.Models.Dtos.Requests
{
    /// <summary>
    /// Data Transfer Object (DTO) para a atualização parcial (PATCH) de uma PartyInteraction.
    /// Todas as propriedades são anuláveis para que o cliente possa enviar apenas
    /// os campos que deseja modificar. A lógica de negócio no servidor será
    /// responsável por aplicar apenas as alterações fornecidas.
    /// </summary>
    public class PartyInteractionUpdateDto
    {
        // --- Atributos de Metadados TMF ---
        // O cliente pode, opcionalmente, querer atualizar os metadados.
        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        // --- Atributos de Negócio ---
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        // O status é um dos campos mais comuns a serem atualizados.
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("interactionDate")]
        public TimePeriodDto? InteractionDate { get; set; }

        // --- Listas de Relacionamentos ---
        // As listas também são anuláveis. Se o cliente enviar a lista,
        // ela será substituída. Se não enviar (null), a lista existente será mantida.
        [JsonPropertyName("relatedParty")]
        public List<RelatedPartyOrPartyRoleDto>? RelatedParty { get; set; }

        [JsonPropertyName("interactionItem")]
        public List<InteractionItemDto>? InteractionItem { get; set; }

        [JsonPropertyName("note")]
        public List<NoteDto>? Note { get; set; }

        [JsonPropertyName("attachment")]
        public List<AttachmentRefOrValueDto>? Attachment { get; set; }

        [JsonPropertyName("relatedChannel")]
        public List<RelatedChannelDto>? RelatedChannel { get; set; }

        [JsonPropertyName("externalIdentifier")]
        public List<ExternalIdentifierDto>? ExternalIdentifier { get; set; }

        [JsonPropertyName("interactionRelationship")]
        public List<InteractionRelationshipDto>? InteractionRelationship { get; set; }
    }
}
