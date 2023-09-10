namespace ChatDev.Annotations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        private const int MinimumLength = 9;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false; // Null values are considered invalid
            }

            var password = value.ToString();

            if (password.Length < MinimumLength)
            {
                return false; // Password length is less than the required minimum
            }

            // Check if the password contains at least one special character, one number, and one letter
            var hasSpecialCharacter = password.Any(char.IsSymbol);
            var hasDigit = password.Any(char.IsDigit);
            var hasLetter = password.Any(char.IsLetter);

            return hasSpecialCharacter && hasDigit && hasLetter;
        }

        public PasswordRequirementsAttribute()
        {
            ErrorMessage = $"The password must be at least {MinimumLength} characters long and contain at least one special character, one number, and one letter.";
        }
    }

}
