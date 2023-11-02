using System.Text.Json.Serialization;

namespace Rest.Web.Model;

public class Login
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}
