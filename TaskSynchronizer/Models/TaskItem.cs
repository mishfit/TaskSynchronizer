using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskSynchronizer.Models
{
    public class TaskItem
    {
        [JsonPropertyName("_id")]
        public required string Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("color")]
        public required string Color { get; set; }
        [JsonPropertyName("columnId")]
        public required string ColumnId { get; set; }
        [JsonPropertyName("totalSecondsSpent")]
        public int TotalSecondsSpent { get; set; }
        [JsonPropertyName("totalSecondsEstimate")]
        public int TotalSecondsEstimate { get; set; }
        [JsonPropertyName("collaborators")]
        public IEnumerable<Collaborator> Collaborators { get; set; } = new List<Collaborator>(); // Optional
        [JsonPropertyName("groupingDate")]
        public DateOnly GroupingDate { get; set; } // Optional - for done tasks
        [JsonPropertyName("customFields")]
        public IEnumerable<CustomField> CustomFields { get; set; } = new List<CustomField>();
    }
}
