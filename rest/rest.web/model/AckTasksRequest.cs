using System.Text.Json.Serialization;

namespace Rest.Web.Model;

public class AckTasksRequest
{
    [JsonPropertyName("tasks")]
    public IEnumerable<int> Tasks { get; set; }
}