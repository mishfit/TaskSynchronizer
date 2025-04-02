using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSynchronizer
{
    public class JiraOptions
    {
        public required string JiraBaseUrl { get; set; }
        public required string JiraUsername { get; set; }
        public required string JiraApiToken { get; set; }
        public required string JiraTaskAssignee { get; set; }
    }
}
