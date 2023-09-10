using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class LetterValidationAttribute : ValidationAttribute
{
    private readonly string pattern;

    public LetterValidationAttribute(string pattern)
    {
        this.pattern = pattern;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Null values are considered valid
        }

        var stringValue = value.ToString();
        var regex = new Regex(pattern);

        if (regex.IsMatch(stringValue))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Invalid input format.");
    }
}
