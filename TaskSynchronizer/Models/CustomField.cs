using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class CustomField
    {

        [JsonPropertyName("customFieldId")]
        public required string Id { get; set; }
        [JsonPropertyName("value")]
        public required CustomFieldValue CustomFieldValue { get; set; }
    }
}