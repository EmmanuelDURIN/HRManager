using HRManager.Properties;
using HRManager.ViewModels;
using System.Windows;

namespace HRManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get => DataContext as MainWindowViewModel; }

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
                //MessageBox.Show($"Person created : {person.Firstname}");
                ViewModel.HireEmployee(person);
            }
            else
            {
                //MessageBox.Show("Cancel clicked");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = Settings.Default.Top;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Top = (int)this.Top;
            Settings.Default.Save();
        }
    }
}
