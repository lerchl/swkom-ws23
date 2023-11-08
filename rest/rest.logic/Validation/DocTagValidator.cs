using Rest.Model;

using static rest.logic.validation.ValidationUtils;

namespace rest.logic.validation {
    /// <summary>
    ///     <see cref="IValidator{T}"/> implementation for <see cref="DocTag"/>s.
    /// </summary>
    /// 

    public class DocTagValidator : IValidator<DocTag> {
        public ValidationResult ValidateSave(DocTag t) {
            var result = new ValidationResult();

            // Slug
            ValidateMaxLength(t.Slug, 255, "Slug", result);

            // Name
            ValidateRequired(t.Name, "Name", result);
            ValidateMaxLength(t.Name, 100, "Name", result);

            // Color
            ValidateRequired(t.Color, "Color", result);
            ValidateMaxLength(t.Color, 20, "Color", result);

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