using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rest.Model;

[Table("document_type")]
public partial class DocumentType : Entity, IEquatable<DocumentType>
{
    [Column("id"), Key]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [Column("slug"), MaxLength(255)]
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [Column("name"), MaxLength(100), Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [Column("match")]
    [JsonPropertyName("match")]
    public string? Match { get; set; }

    [Column("matching_algorithm"), Required]
    [JsonPropertyName("matching_algorithm")]
    public long MatchingAlgorithm { get; set; }

    [Column("is_insensitive"), Required]
    [JsonPropertyName("is_insensitive")]
    public bool IsInsensitive { get; set; }

    [Column("document_count"), Required]
    [JsonPropertyName("document_count")]
    public long DocumentCount { get; set; }

    /// <summary>
    /// Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class DocumentType {\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Slug: ").Append(Slug).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Match: ").Append(Match).Append("\n");
        sb.Append("  MatchingAlgorithm: ").Append(MatchingAlgorithm).Append("\n");
        sb.Append("  IsInsensitive: ").Append(IsInsensitive).Append("\n");
        sb.Append("  DocumentCount: ").Append(DocumentCount).Append("\n");
        sb.Append("}\n");
        return sb.ToString();
    }

    /// <summary>
    /// Returns the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    /// <summary>
    /// Returns true if objects are equal
    /// </summary>
    /// <param name="obj">Object to be compared</param>
    /// <returns>Boolean</returns>
    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((DocumentType)obj);
    }

    /// <summary>
    /// Returns true if DocumentType instances are equal
    /// </summary>
    /// <param name="other">Instance of DocumentType to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(DocumentType other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return
            (
                Id == other.Id ||

                Id.Equals(other.Id)
            ) &&
            (
                Slug == other.Slug ||
                Slug != null &&
                Slug.Equals(other.Slug)
            ) &&
            (
                Name == other.Name ||
                Name != null &&
                Name.Equals(other.Name)
            ) &&
            (
                Match == other.Match ||
                Match != null &&
                Match.Equals(other.Match)
            ) &&
            (
                MatchingAlgorithm == other.MatchingAlgorithm ||

                MatchingAlgorithm.Equals(other.MatchingAlgorithm)
            ) &&
            (
                IsInsensitive == other.IsInsensitive ||

                IsInsensitive.Equals(other.IsInsensitive)
            ) &&
            (
                DocumentCount == other.DocumentCount ||

                DocumentCount.Equals(other.DocumentCount)
            );
    }

    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            var hashCode = 41;
            // Suitable nullity checks etc, of course :)

            hashCode = hashCode * 59 + Id.GetHashCode();
            if (Slug != null)
                hashCode = hashCode * 59 + Slug.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Match != null)
                hashCode = hashCode * 59 + Match.GetHashCode();

            hashCode = hashCode * 59 + MatchingAlgorithm.GetHashCode();

            hashCode = hashCode * 59 + IsInsensitive.GetHashCode();

            hashCode = hashCode * 59 + DocumentCount.GetHashCode();
            return hashCode;
        }
    }

    public override long GetId()
    {
        return Id;
    }

    #region Operators
#pragma warning disable 1591

    public static bool operator ==(DocumentType left, DocumentType right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(DocumentType left, DocumentType right)
    {
        return !Equals(left, right);
    }

#pragma warning restore 1591
    #endregion Operators
}
