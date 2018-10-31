using System.Configuration;
using FirstFloor.ModernUI.Windows.Controls;
using Ninject;
using Ninject.Modules;
using VTaxi.BLL.Infrastructure;
using VTaxi.Util;

namespace VTaxi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            NinjectModule serviceModule = new ServiceModule(ConfigurationManager.ConnectionStrings["VTaxiDB"].ConnectionString);
            NinjectModule authenticationModule = new AuthenticationModule();
            var kernel = new StandardKernel(serviceModule, authenticationModule);
        }
    }
}
