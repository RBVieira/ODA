using System.Text.Json.Serialization;

namespace Tmf683.PartyInteraction.Api.Models.Dtos
{
    public class AttachmentRefOrValueDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("mimeType")]
        public string? MimeType { get; set; }

        [JsonPropertyName("size")]
        public long? Size { get; set; }

        [JsonPropertyName("validFor")]
        public TimePeriodDto? ValidFor { get; set; }

        [JsonPropertyName("@baseType")]
        public string? BaseType { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; } // Discriminador: "Attachment" ou "AttachmentRef"

        [JsonPropertyName("@schemaLocation")]
        public string? SchemaLocation { get; set; }

        [JsonPropertyName("@referredType")]
        public string? ReferredType { get; set; }
    }

    // DTO auxiliar para o período de validade
    public class TimePeriodDto
    {
        [JsonPropertyName("startDateTime")]
        public DateTime? StartDateTime { get; set; }

        [JsonPropertyName("endDateTime")]
        public DateTime? EndDateTime { get; set; }
    }
}
