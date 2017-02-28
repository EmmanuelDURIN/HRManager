using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRManager
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void HireEmployeeClick(object sender, RoutedEventArgs e)
    {
      AddPersonWindow window = new AddPersonWindow();
      bool? result = window.ShowDialog();
      if (result == true)
      {
        Person person = window.HiredPerson;
        MessageBox.Show($"Person created : {person.Firstname}");
      }
      else
      {
        MessageBox.Show("Cancel clicked");
      }
    }
  }
}
