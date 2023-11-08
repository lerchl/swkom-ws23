namespace rest.logic.validation {
    /// <summary>
    ///     Result of a validation.
    /// </summary>
    public class ValidationResult {

        public List<ValidationMessage> Messages { get; } = new();

        public bool Valid {
            get => !Messages.Where(m => m.Status == ValidationMessageStatus.Error).Any();
        }

        // /////////////////////////////////////////////////////////////////////////
        // Methods
        // /////////////////////////////////////////////////////////////////////////

        /// <summary>
        ///     Add a message to the result.
        /// </summary>
        /// <param name="message">the message</param>
        public void AddMessage(ValidationMessage message) {
            Messages.Add(message);
        }
    }
}
