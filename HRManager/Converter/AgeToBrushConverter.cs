using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HRManager.Converter
{
  public class AgeToBrushConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      int age = (int)value;

      //return new SolidColorBrush(Colors.Coral);
      //return Brushes.Coral;
      //return new LinearGradientBrush( ... );
      //return new SolidColorBrush(Color.FromArgb(255, 180, 0, 0));
      if (age >= 18)
        return App.Current.Resources["brushAdult"];
      else
        return App.Current.Resources["brushChild"];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      // on n'implémente pas cette deuxième méthode
      // Car on ne permet pas d'édition de couleur, seulement de l'affichage
      throw new NotImplementedException();
    }
  }
}
