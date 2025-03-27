using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class JiraWorklogContainer
    {
        [JsonPropertyName("startAt")]
        public int StartAt { get; set; }

        [JsonPropertyName("maxResults")]
        public int MaxResults { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("worklogs")]
        public IEnumerable<JiraWorklog> Worklogs { get; set; } = new List<JiraWorklog>();
    }
}