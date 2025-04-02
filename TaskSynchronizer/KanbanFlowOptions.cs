using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSynchronizer
{
    public class KanbanFlowOptions
    {
        public required string KanbanFlowBaseUrl { get; set; }
        public required string KanbanFlowUsername { get; set; }
        public required string KanbanFlowApiToken { get; set; }
    }
}
