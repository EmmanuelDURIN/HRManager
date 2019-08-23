using HRManager.BusinessObjects;
using HRManager.ValidationRules;
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
using System.Windows.Shapes;

namespace HRManager
{
    /// <summary>
    /// Interaction logic for AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public AddPersonWindow()
        {
            InitializeComponent();
            // Databinding du très pauvre :
            this.HiredPerson = new Person { Age = 45, Firstname = "Emmanuel" };
            this.DataContext = this.HiredPerson;

        }

        // Cette propriété permet à l'appelant du formulaire de retrouver la personne embauchée
        public Person HiredPerson { get; set; }

        private void ButtonOKClick(object sender, RoutedEventArgs e)
        {
            ValidationHelper.ValidateAllChildren(this);
            if (ValidationHelper.IsValid(this))
                DialogResult = true;
        }

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            personUserControl.Focus();
        }
    }
}
