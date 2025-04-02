using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskSynchronizer.Models
{
    public class JiraIssueSearchResult
    {
        [JsonPropertyName("expand")]
        public string? Expand { get; set; }
        [JsonPropertyName("startAt")]
        public int StartAt { get; set; }
        [JsonPropertyName("maxResults")]
        public int MaxResults {  get; set; }
        [JsonPropertyName("issues")]
        public IEnumerable<JiraIssue> Issues { get; set; } = new List<JiraIssue>();
    }
}
