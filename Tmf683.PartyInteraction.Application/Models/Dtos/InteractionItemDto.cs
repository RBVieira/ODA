using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Application.Models.Dtos
{
    public class InteractionItemDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("itemType")]
        public string? ItemType { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("lastUpdate")]
        public DateTime? LastUpdate { get; set; }

        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        // --- Relacionamentos do próprio Item ---
        [JsonPropertyName("note")]
        public List<NoteDto>? Note { get; set; }

        [JsonPropertyName("attachment")]
        public List<AttachmentRefOrValueDto>? Attachment { get; set; }

        [JsonPropertyName("relatedParty")]
        public List<RelatedPartyOrPartyRoleDto>? RelatedParty { get; set; }
    }
}
