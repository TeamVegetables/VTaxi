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
using Ninject;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;
using VTaxi.Util;

namespace VTaxi.Pages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {

        public Profile()
        {
            InitializeComponent();
            DataContext = AuthenticationService.CurrentUser;
        }
    }
}
