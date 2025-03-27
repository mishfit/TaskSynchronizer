using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class JiraStatusCategory
    {
        [JsonPropertyName("self")]
        public required string Self { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("key")]
        public required string Key { get; set; }

        [JsonPropertyName("colorName")]
        public string? ColorName { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}