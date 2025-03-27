using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class JiraField
    {
        [JsonPropertyName("statusCategory")]
        public JiraStatusCategory StatusCategory { get; set; }

        [JsonPropertyName("progress")]
        public JiraProgress Progress { get; set; }

        [JsonPropertyName("assignee")]
        public JiraUser Assignee { get; set; }

        [JsonPropertyName("worklog")]
        public JiraWorklogContainer Worklog { get; set; }

        [JsonPropertyName("issuetype")]
        public JiraIssueType IssueType { get; set; }

        [JsonPropertyName("timetracking")]
        public JiraTimeTracking TimeTracking { get; set; }
    }
}