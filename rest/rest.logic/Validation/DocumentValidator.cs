using Rest.Model;

using static rest.logic.validation.ValidationUtils;

namespace rest.logic.validation {
    /// <summary>
    ///     <see cref="IValidator{T}"/> implementation for <see cref="Document"/>s.
    /// </summary>
    /// 
    
    public class DocumentValidator : IValidator<Document> {
        public ValidationResult ValidateSave(Document t) {
            var result = new ValidationResult();

            // Title
            ValidateRequired(t.Title, "Title", result);
            ValidateMaxLength(t.Title, 255, "Title", result);

            // Content
            ValidateRequired(t.Content, "Content", result);

            // Created
            ValidateRequired(t.Created, "Created", result);

            // CreatedDate
            ValidateRequired(t.CreatedDate, "CreatedDate", result);

            // Modified
            ValidateRequired(t.Modified, "Modified", result);

            // Added
            ValidateRequired(t.Added, "Added", result);

            // ArchiveSerialNumber
            ValidateRequired(t.ArchiveSerialNumber, "ArchiveSerialNumber", result);

            // OriginalFileName
            ValidateRequired(t.OriginalFileName, "OriginalFileName", result);

            // ArchivedFileName
            ValidateRequired(t.ArchivedFileName, "ArchivedFileName", result);

            return result;
        }
    }
}
