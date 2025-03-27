using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskSynchronizer.Models
{
    public class BoardColumn
    {
        [JsonPropertyName("columnId")]
        public required string ColumnId { get; set; }
        [JsonPropertyName("columnName")]
        public required string ColumnName { get; set; }
        [JsonPropertyName("tasksLimited")]
        public bool TasksLimited { get; set; }
        [JsonPropertyName("tasks")]
        public IEnumerable<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        [JsonPropertyName("nextTaskId")]
        public string? NextTaskId { get; set; } // Optional - appears only in the last column
    }
}
