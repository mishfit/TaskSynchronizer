using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class JiraTimeTracking
    {
        [JsonPropertyName("remainingEstimate")]
        public string RemainingEstimate { get; set; }

        [JsonPropertyName("timeSpent")]
        public string TimeSpent { get; set; }

        [JsonPropertyName("remainingEstimateSeconds")]
        public int RemainingEstimateSeconds { get; set; }

        [JsonPropertyName("timeSpentSeconds")]
        public int TimeSpentSeconds { get; set; }
    }}