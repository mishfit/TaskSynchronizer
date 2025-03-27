using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class Progress
    {
        [JsonPropertyName("progress")]
        public int ProgressValue { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("percent")]
        public int Percent { get; set; }
    }
}