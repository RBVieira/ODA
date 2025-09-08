using System.Text.Json.Serialization;
using Tmf683.PartyInteraction.Application.Models.Dtos;

namespace Tmf683.PartyInteraction.Application.Models.Dtos.Responses
{
    public class PartyInteractionResponseDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("interactionStartDate")]
        public DateTime? InteractionStartDate { get; set; }

        [JsonPropertyName("interactionEndDate")]
        public DateTime? InteractionEndDate { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("lastUpdateDate")]
        public DateTime? LastUpdateDate { get; set; }

        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        [JsonPropertyName("externalIdentifier")]
        public List<ExternalIdentifierDto> ExternalIdentifier { get; set; } = new();

        [JsonPropertyName("relatedParty")]
        public List<RelatedPartyOrPartyRoleDto> RelatedParty { get; set; } = new();

        [JsonPropertyName("interactionItem")]
        public List<InteractionItemDto> InteractionItem { get; set; } = new();

        [JsonPropertyName("note")]
        public List<NoteDto> Note { get; set; } = new();
    }
}
