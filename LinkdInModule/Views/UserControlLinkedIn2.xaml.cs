using LinkedInModule.Services;
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

namespace LinkedInModule.Views
{
    /// <summary>
    /// Logique d'interaction pour UserControlLinkedIn2.xaml
    /// </summary>
    public partial class UserControlLinkedIn2 : UserControl
    {
        private IPeopleService peopleService;
        public UserControlLinkedIn2(IPeopleService peopleService)
        {
            InitializeComponent();
            this.peopleService = peopleService;
        }
    }
}
