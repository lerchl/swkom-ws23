using Rest.Model;

using static Rest.Logic.Validation.ValidationUtils;

namespace Rest.Logic.Validation {
    
    /// <summary>
    ///     <see cref="IValidator{T}"/> implementation for <see cref="Correspondent"/>s.
    /// </summary>
    public class CorrespondentValidator : IValidator<Correspondent> {
        public ValidationResult ValidateSave(Correspondent t) {
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

            // LastCorrespondence
            ValidateRequired(t.LastCorrespondence, "LastCorrespondence", result);

            return result;
        }
    }
}