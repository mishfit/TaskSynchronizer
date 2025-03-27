using System.Text.Json.Serialization;

namespace TaskSynchronizer.Models
{
    public class JiraAvatarUrls
    {
        [JsonPropertyName("48x48")]
        public string Size48 { get; set; }

        [JsonPropertyName("24x24")]
        public string Size24 { get; set; }

        [JsonPropertyName("16x16")]
        public string Size16 { get; set; }

        [JsonPropertyName("32x32")]
        public string Size32 { get; set; }
    }
}