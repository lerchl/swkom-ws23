using static rest.logic.validation.ValidationMessageStatus;

namespace rest.logic.validation {
    public static class ValidationUtils {

        // strings

        /// <summary>
        ///     Validate a required object.
        /// </summary>
        /// <param name="o">the object</param>
        /// <param name="name">the name of the variable for displaying errors</param>
        /// <param name="result">the validation result</param>
        public static void ValidateRequired(object? o, string name, ValidationResult result) {
            if (o == null) {
                result.AddMessage(new(Error, $"{name} is required"));
            }
        }

        /// <summary>
        ///    Validate a string for a minimum length.
        /// </summary>
        /// <param name="s">the string</param>
        /// <param name="minLength">the minimum length</param>
        /// <param name="name">the name of the variable for displaying errors</param>
        /// <param name="result">the validation result</param>
        public static void ValidateMinLength(string? s, int minLength, string name, ValidationResult result) {
            if (s?.Length < minLength) {
                result.AddMessage(new(Error, $"{name} is too short (min. {minLength} characters)"));
            }
        }

        /// <summary>
        ///     Validate a string for a maximum length.
        /// </summary>
        /// <param name="s">the string</param>
        /// <param name="maxLength">the maximum length</param>
        /// <param name="name">the name of the variable for displaying errors</param>
        /// <param name="result">the validation result</param>
        public static void ValidateMaxLength(string? s, int maxLength, string name, ValidationResult result) {
            if (s?.Length > maxLength) {
                result.AddMessage(new(Error, $"{name} is too long (max. {maxLength} characters)"));
            }
        }

        /// <summary>
        ///     Validate a required string for a minimum and maximum length.
        /// </summary>
        /// <param name="s">the string</param>
        /// <param name="minLength">the minimum length</param>
        /// <param name="maxLength">the maximum length</param>
        /// <param name="name">the name of the variable for displaying errors</param>
        /// <param name="result">the validation result</param>
        public static void ValidateRequiredString(string? s, int minLength, int maxLength, string name, ValidationResult result) {
            ValidateRequired(s, name, result);
            ValidateMinLength(s, minLength, name, result);
            ValidateMaxLength(s, maxLength, name, result);
        }

        // numbers

        /// <summary>
        ///     Validate a number for a minimum value.
        /// </summary>
        /// <param name="value">the number</param>
        /// <param name="minValue">the minimum value</param>
        /// <param name="name">the name of the variable for displaying errors</param>
        /// <param name="result">the validation result</param>
        public static void ValidateMinValue(decimal value, decimal minValue, string name, ValidationResult result) {
            if (value < minValue) {
                result.AddMessage(new(Error, $"{name} is too small (min. {minValue})"));
            }
        }
    }
}
