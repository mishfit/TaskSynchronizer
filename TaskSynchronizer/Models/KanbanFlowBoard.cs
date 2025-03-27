using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskSynchronizer.Models
{
    internal class KanbanFlowBoard
    {
        [JsonPropertyName("_id")]
        public required string Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("columns")]
        public IEnumerable<BoardColumn> Columns { get; set; } = new List<BoardColumn>();

        [JsonPropertyName("colors")]
        public IEnumerable<BoardColor> Colors { get; set; } = new List<BoardColor>();
    }
}
