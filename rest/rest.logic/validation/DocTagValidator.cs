using Rest.Model;

using static Rest.Logic.Validation.ValidationUtils;

namespace Rest.Logic.Validation {
    
    /// <summary>
    ///     <see cref="IValidator{T}"/> implementation for <see cref="DocTag"/>s.
    /// </summary>
    public class DocTagValidator : IValidator<DocTag> {
        public ValidationResult ValidateSave(DocTag t) {
            var result = new ValidationResult();

            // Slug
            ValidateMaxLength(t.Slug, 255, "Slug", result);

            // Name
            ValidateRequiredString(t.Name, 1, 100, "Name", result);

            // Color
            ValidateRequiredString(t.Color, 1, 20, "Color", result);

            // MatchingAlgorithm
            ValidateRequired(t.MatchingAlgorithm, "MatchingAlgorithm", result);

            // IsInsensitive
            ValidateRequired(t.IsInsensitive, "IsInsensitive", result);

            // IsInboxTag
            ValidateRequired(t.IsInboxTag, "IsInboxTag", result);

            // DocumentCount
            ValidateRequired(t.DocumentCount, "DocumentCount", result);

            return result;
        }
    }
}