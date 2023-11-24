using System.Text.Json.Serialization;

namespace Mock_Server.Models;

public class AckTasksRequest
{
    [JsonPropertyName("task")]
    public IEnumerable<int> Task { get; set; }
}
