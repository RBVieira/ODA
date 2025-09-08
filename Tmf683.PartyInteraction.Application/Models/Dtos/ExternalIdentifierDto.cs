using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Application.Models.Dtos
{
    public class ExternalIdentifierDto
    {
        [JsonPropertyName("id")]
        public string ExternalIdValue { get; set; } // O ID no sistema externo

        [JsonPropertyName("externalIdentifierType")]
        public string? ExternalIdType { get; set; } // O tipo de ID

        [JsonPropertyName("owner")]
        public string? Owner { get; set; } // O sistema dono do ID

        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }
    }
}