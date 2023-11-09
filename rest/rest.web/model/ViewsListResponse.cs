using System.Text.Json.Serialization;

namespace Rest.Web.Model;

public partial class ViewsListResponse : ListResponse<SavedView>
{
    [JsonPropertyName("all")]
    public int[] All { get; set; }
}
