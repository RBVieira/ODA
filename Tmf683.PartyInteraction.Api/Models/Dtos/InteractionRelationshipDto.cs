using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Dtos
{
    public class InteractionRelationshipDto
    {
        [JsonPropertyName("id")]
        public string TargetInteractionId { get; set; } // ID da outra interação

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("relationshipType")]
        public string? RelationshipType { get; set; }

        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        [JsonPropertyName("@referredType")]
        public string? ReferredType { get; set; }
    }
}