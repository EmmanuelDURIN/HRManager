using System;
using System.Globalization;
using System.Windows.Controls;

namespace HRManager.ValidationRules
{
    public class RequiredValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String s = value as String;
            if (String.IsNullOrWhiteSpace(s))
            {
                return new ValidationResult(false, String.Format("Required field"));
            }
            //return new ValidationResult(true, null);
            return ValidationResult.ValidResult;
        }
    }
}