using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HRManager.ValidationRules
{
  public static class ValidationHelper
  {
    public static bool IsValid(this DependencyObject obj)
    {
      // The dependency object is valid if it has no errors and all
      // of its children (that are dependency objects) are error-free.
      return !Validation.GetHasError(obj) &&
          LogicalTreeHelper.GetChildren(obj)
          .OfType<DependencyObject>()
          .All(IsValid);
    }
  }
}
