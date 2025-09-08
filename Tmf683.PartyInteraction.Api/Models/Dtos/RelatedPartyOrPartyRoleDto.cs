using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Dtos
{
    public class RelatedPartyOrPartyRoleDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } // ID da Party ou PartyRole referenciada

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; } // O papel nesta interação

        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        [JsonPropertyName("@referredType")]
        public string? ReferredType { get; set; } // Discriminador: "Party" ou "PartyRole"
    }
}