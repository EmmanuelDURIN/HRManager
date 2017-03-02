using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HRManager.ValidationRules
{
  public class NumberRangeValidationRule : ValidationRule
  {
    public int Min { get; set; }
    public int Max { get; set; }
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      int number;
      if (Int32.TryParse(value.ToString(), out number))
      {
        if (!(Min <= number && number <= Max))
          return new ValidationResult(false,
            String.Format("Number must be in range {0} - {1}", Min, Max));
      }
      return ValidationResult.ValidResult;
    }
  }
}
