using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSynchronizer.Models
{
    public class JiraIssue
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("self")]
        public required string Self { get; set; }

        [JsonPropertyName("key")]
        public required string Key { get; set; }

        [JsonPropertyName("fields")]
        public IEnumerable<JiraField> Fields { get; set; } = new List<JiraField>();
    }
}
