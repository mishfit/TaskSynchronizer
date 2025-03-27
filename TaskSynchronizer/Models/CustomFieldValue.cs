using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class CustomFieldValue
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }
    }
}