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
using VTaxi.BLL.Interfaces;

namespace VTaxi.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private IAuthenticationService _service;

        public Login(IAuthenticationService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void OnClickRegister(object sender, EventArgs e)
        {
            NavigationCommands.GoToPage.Execute("Pages/Register.xaml", this);
        }
    }
}
