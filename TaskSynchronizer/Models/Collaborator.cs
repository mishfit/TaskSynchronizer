using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskSynchronizer.Models
{
    public class Collaborator
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    }
}
