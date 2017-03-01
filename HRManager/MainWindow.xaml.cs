using HRManager.Viewmodel;
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
    private MainWindowViewModel viewModel;
    public MainWindow()
    {
      InitializeComponent();
      viewModel = new MainWindowViewModel();
      DataContext = viewModel;
    }
    private void HireEmployeeClick(object sender, RoutedEventArgs e)
    {
      AddPersonWindow window = new AddPersonWindow();
      bool? result = window.ShowDialog();
      if (result == true)
      {
        Person person = window.HiredPerson;
        //MessageBox.Show($"Person created : {person.Firstname}");
        viewModel.HireEmployee(person);
      }
      else
      {
        MessageBox.Show("Cancel clicked");
      }
    }
  }
}
