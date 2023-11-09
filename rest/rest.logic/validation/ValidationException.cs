namespace Rest.Logic.Validation {
    /// <summary>
    ///     Exception thrown when a validation fails.
    /// </summary>
    public class ValidationException : Exception {

        public ValidationResult Result { get; }

        // /////////////////////////////////////////////////////////////////////////
        // Init
        // /////////////////////////////////////////////////////////////////////////

        public ValidationException(ValidationResult result) : base("Validation failed, see result.") {
            Result = result;
        }
    }
}
