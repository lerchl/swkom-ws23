using Rest.Model;

using static Rest.Logic.Validation.ValidationUtils;

namespace Rest.Logic.Validation {

    /// <summary>
    ///     <see cref="IValidator{T}"/> implementation for <see cref="UserInfo"/>s.
    /// </summary>
    /// 
    public class UserInfoValidator : IValidator<UserInfo> {
        public ValidationResult ValidateSave(UserInfo t) {
            var result = new ValidationResult();

            // Username
            ValidateRequired(t.Username, "Username", result);

            // Password
            ValidateRequired(t.Password, "Password", result);
            ValidateMaxLength(t.Password, 70, "Password", result);

            return result;
        }
    }
}