using System.Windows.Controls;
using VTaxi.BLL.Services;

namespace VTaxi.Pages
{
    /// <summary>
    ///     Interaction logic for Profile.xaml
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