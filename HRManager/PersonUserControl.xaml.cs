﻿using System;
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
  /// Interaction logic for PersonUserControl.xaml
  /// </summary>
  public partial class PersonUserControl : UserControl
  {
    public PersonUserControl()
    {
      InitializeComponent();
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      textboxFirstname.Focus();
    }
    // Ajout éventuel de (Dependency) Propriétés,  events, méthodes
  }
}
