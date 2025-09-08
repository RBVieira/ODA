using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tmf683.PartyInteraction.Api.Models.Dtos; // Namespace para os DTOs aninhados

namespace Tmf683.PartyInteraction.Api.Models.Dtos.Requests
{
    /// <summary>
    /// Data Transfer Object (DTO) para a criação de uma nova PartyInteraction.
    /// Este DTO define o contrato da API para a operação POST, garantindo que
    /// o cliente forneça apenas os dados necessários, em conformidade com a TMF683.
    /// </summary>
    public class PartyInteractionCreateDto
    {
        // --- Atributos de Metadados TMF ---
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

        [JsonPropertyName("interactionDate")]
        public TimePeriodDto? InteractionDate { get; set; }

        // --- Listas de Relacionamentos ---

        // Uma interação deve ter pelo menos uma parte relacionada para ser válida.
        [Required]
        [JsonPropertyName("relatedParty")]
        public List<RelatedPartyOrPartyRoleDto> RelatedParty { get; set; } = new();

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