namespace rest.logic.validation {
    /// <summary>
    ///     Interface for a validator.
    /// </summary>
    public interface IValidator<T> {

        /// <summary>
        ///     Validate an entity for saving.
        /// </summary>
        /// <param name="t">the entity</param>
        /// <returns>the validation result</returns>
        ValidationResult ValidateSave(T t);
    }
}
