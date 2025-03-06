using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    private static readonly string jiraBaseUrl = "https://yourdomain.atlassian.net/rest/api/2/search";
    private static readonly string jiraUsername = "your-email@example.com";
    private static readonly string jiraApiToken = "your-jira-api-token";
    private static readonly string kanbanFlowApiUrl = "https://kanbanflow.com/api/v1/tasks";
    private static readonly string kanbanFlowApiToken = "your-kanbanflow-api-token";

    static async Task Main(string[] args)
    {
        try
        {
            var jiraTasks = await GetJiraTasksAsync();
            if (jiraTasks != null)
            {
                foreach (var task in jiraTasks.Issues)
                {
                    await CreateKanbanFlowTask(task);
                }
                Console.WriteLine("Tasks successfully exported to KanbanFlow!");
            }
            else
            {
                Console.WriteLine("No tasks found in Jira.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static async Task<JiraResponse> GetJiraTasksAsync()
    {
        using (var client = new HttpClient())
        {
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{jiraUsername}:{jiraApiToken}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            
            string jqlQuery = "{\"jql\": \"project = YOUR_PROJECT_KEY AND status = 'To Do'\", \"maxResults\": 10}";
            var content = new StringContent(jqlQuery, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(jiraBaseUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JiraResponse>(result);
            }
            else
            {
                Console.WriteLine($"Failed to get Jira tasks: {response.ReasonPhrase}");
                return null;
            }
        }
    }

    public static async Task CreateKanbanFlowTask(JiraIssue issue)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", kanbanFlowApiToken);
            
            var kanbanTask = new
            {
                name = issue.Fields.Summary,
                description = issue.Fields.Description,
                columnId = "your-column-id",  // Set your KanbanFlow column ID
                swimlaneId = "your-swimlane-id" // Optional swimlane ID
            };

            var json = JsonSerializer.Serialize(kanbanTask);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(kanbanFlowApiUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed to create KanbanFlow task: {response.ReasonPhrase}");
            }
        }
    }
}

// Jira API Response Models
public class JiraResponse
{
    public JiraIssue[] Issues { get; set; }
}

public class JiraIssue
{
    public string Id { get; set; }
    public JiraFields Fields { get; set; }
}

public class JiraFields
{
    public string Summary { get; set; }
    public string Description { get; set; }
}
