using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest.Model {
    /// <summary>
    /// 
    /// </summary>
    [Table("document")]
    public partial class Document : Entity, IEquatable<Document> {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Column("id"), Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Correspondent
        /// </summary>
        [Column("correspondent")]
        public Correspondent? Correspondent { get; set; }

        /// <summary>
        /// Gets or Sets DocumentType
        /// </summary>
        [Column("document_type")]
        public DocumentType? DocumentType { get; set; }

        /// <summary>
        /// Gets or Sets StoragePath
        /// </summary>
        [Column("storage_path")]
        public int? StoragePath { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [Column("title"), MaxLength(255), Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [Column("content"), Required]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [Column("tags"), Required]
        public List<DocTag> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [Column("created"), Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [Column("created_date"), Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets Modified
        /// </summary>
        [Column("modified"), Required]
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or Sets Added
        /// </summary>
        [Column("added"), Required]
        public DateTime Added { get; set; }

        /// <summary>
        /// Gets or Sets ArchiveSerialNumber
        /// </summary>
        [Column("archive_serial_number"), Required]
        public string ArchiveSerialNumber { get; set; }

        /// <summary>
        /// Gets or Sets OriginalFileName
        /// </summary>
        [Column("original_file_name"), Required]
        public string OriginalFileName { get; set; }

        /// <summary>
        /// Gets or Sets ArchivedFileName
        /// </summary>
        [Column("archived_file_name"), Required]
        public string ArchivedFileName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Document {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Correspondent: ").Append(Correspondent).Append("\n");
            sb.Append("  DocumentType: ").Append(DocumentType).Append("\n");
            sb.Append("  StoragePath: ").Append(StoragePath).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Modified: ").Append(Modified).Append("\n");
            sb.Append("  Added: ").Append(Added).Append("\n");
            sb.Append("  ArchiveSerialNumber: ").Append(ArchiveSerialNumber).Append("\n");
            sb.Append("  OriginalFileName: ").Append(OriginalFileName).Append("\n");
            sb.Append("  ArchivedFileName: ").Append(ArchivedFileName).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Document)obj);
        }

        /// <summary>
        /// Returns true if Document instances are equal
        /// </summary>
        /// <param name="other">Instance of Document to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Document other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    
                    Id.Equals(other.Id)
                ) && 
                (
                    Correspondent == other.Correspondent ||
                    Correspondent != null &&
                    Correspondent.Equals(other.Correspondent)
                ) && 
                (
                    DocumentType == other.DocumentType ||
                    DocumentType != null &&
                    DocumentType.Equals(other.DocumentType)
                ) && 
                (
                    StoragePath == other.StoragePath ||
                    StoragePath != null &&
                    StoragePath.Equals(other.StoragePath)
                ) && 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
                ) && 
                (
                    Tags == other.Tags ||
                    Tags != null &&
                    other.Tags != null &&
                    Tags.SequenceEqual(other.Tags)
                ) && 
                (
                    Created == other.Created ||
                    Created != null &&
                    Created.Equals(other.Created)
                ) && 
                (
                    CreatedDate == other.CreatedDate ||
                    CreatedDate != null &&
                    CreatedDate.Equals(other.CreatedDate)
                ) && 
                (
                    Modified == other.Modified ||
                    Modified != null &&
                    Modified.Equals(other.Modified)
                ) && 
                (
                    Added == other.Added ||
                    Added != null &&
                    Added.Equals(other.Added)
                ) && 
                (
                    ArchiveSerialNumber == other.ArchiveSerialNumber ||
                    ArchiveSerialNumber != null &&
                    ArchiveSerialNumber.Equals(other.ArchiveSerialNumber)
                ) && 
                (
                    OriginalFileName == other.OriginalFileName ||
                    OriginalFileName != null &&
                    OriginalFileName.Equals(other.OriginalFileName)
                ) && 
                (
                    ArchivedFileName == other.ArchivedFileName ||
                    ArchivedFileName != null &&
                    ArchivedFileName.Equals(other.ArchivedFileName)
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
                    if (Correspondent != null)
                    hashCode = hashCode * 59 + Correspondent.GetHashCode();
                    if (DocumentType != null)
                    hashCode = hashCode * 59 + DocumentType.GetHashCode();
                    if (StoragePath != null)
                    hashCode = hashCode * 59 + StoragePath.GetHashCode();
                    if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                    if (Tags != null)
                    hashCode = hashCode * 59 + Tags.GetHashCode();
                    if (Created != null)
                    hashCode = hashCode * 59 + Created.GetHashCode();
                    if (CreatedDate != null)
                    hashCode = hashCode * 59 + CreatedDate.GetHashCode();
                    if (Modified != null)
                    hashCode = hashCode * 59 + Modified.GetHashCode();
                    if (Added != null)
                    hashCode = hashCode * 59 + Added.GetHashCode();
                    if (ArchiveSerialNumber != null)
                    hashCode = hashCode * 59 + ArchiveSerialNumber.GetHashCode();
                    if (OriginalFileName != null)
                    hashCode = hashCode * 59 + OriginalFileName.GetHashCode();
                    if (ArchivedFileName != null)
                    hashCode = hashCode * 59 + ArchivedFileName.GetHashCode();
                return hashCode;
            }
        }

        public override long GetId() {
            return Id;
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Document left, Document right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Document left, Document right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
