using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

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
        /// <summary>
        /// Proceed to validation of an object and make errors apparent
        /// </summary>
        /// <param name="parent"></param>
        internal static bool ValidateAllChildren(DependencyObject parent)
        {
            // Validate all the bindings on the parent
            //Debug.WriteLine("Validating {0} " , parent);
            bool valid = true;
            LocalValueEnumerator localValues = parent.GetLocalValueEnumerator();
            while (localValues.MoveNext())
            {
                LocalValueEntry entry = localValues.Current;
                if (BindingOperations.IsDataBound(parent, entry.Property))
                {
                    Binding binding = BindingOperations.GetBinding(parent, entry.Property);
                    foreach (ValidationRule rule in binding.ValidationRules)
                    {
                        ValidationResult result = rule.Validate(parent.GetValue(entry.Property), null);
                        if (!result.IsValid)
                        {
                            BindingExpression expression = BindingOperations.GetBindingExpression(parent, entry.Property);
                            System.Windows.Controls.Validation.MarkInvalid(expression, new ValidationError(rule, expression, result.ErrorContent, null));
                            valid = false;
                        }
                    }
                }
            }
            // Validate all the bindings on the children
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (!ValidateAllChildren(child))
                    valid = false;
            }
            return valid;
        }
        //internal static void ValidateAllChildren(DependencyObject parent)
        //{
        //    // Validate all the bindings on the parent
        //    //Debug.WriteLine("Validating {0} " , parent);
        //    Validation.GetErrors(parent);
        //    for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
        //    {
        //        DependencyObject child = VisualTreeHelper.GetChild(parent, i);
        //        ValidateAllChildren(child);
        //    }
        //}
    }
}
