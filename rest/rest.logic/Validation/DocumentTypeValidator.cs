using Rest.Model;

using static rest.logic.validation.ValidationUtils;

namespace rest.logic.validation {
    /// <summary>
    ///     <see cref="IValidator{T}"/> implementation for <see cref="DocumentType"/>s.
    /// </summary>
    /// 

    public class DocumentTypeValidator : IValidator<DocumentType> {
        public ValidationResult ValidateSave(DocumentType t) {
            var result = new ValidationResult();

            // Slug
            ValidateMaxLength(t.Slug, 255, "Slug", result);

            // Name
            ValidateRequired(t.Name, "Name", result);
            ValidateMaxLength(t.Name, 100, "Name", result);

            // MatchingAlgorithm
            ValidateRequired(t.MatchingAlgorithm, "MatchingAlgorithm", result);

            // IsInsensitive
            ValidateRequired(t.IsInsensitive, "IsInsensitive", result);

            // DocumentCount
            ValidateRequired(t.DocumentCount, "DocumentCount", result);

            return result;
        }
    }
}