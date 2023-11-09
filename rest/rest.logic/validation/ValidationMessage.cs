namespace Rest.Logic.Validation {
    public class ValidationMessage {

        public ValidationMessageStatus Status { get; }
        public string Message { get; }

        public ValidationMessage(ValidationMessageStatus status, string message) {
            Status = status;
            Message = message;
        }
    }
}
