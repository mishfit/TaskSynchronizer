using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class JiraWorklog
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }

        [JsonPropertyName("author")]
        public JiraUser Author { get; set; }

        [JsonPropertyName("updateAuthor")]
        public JiraUser UpdateAuthor { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("started")]
        public string Started { get; set; }

        [JsonPropertyName("timeSpent")]
        public string TimeSpent { get; set; }

        [JsonPropertyName("timeSpentSeconds")]
        public int TimeSpentSeconds { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("issueId")]
        public string IssueId { get; set; }
    }
}