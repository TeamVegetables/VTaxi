using System.Configuration;
using Ninject;
using Ninject.Modules;
using VTaxi.BLL.Infrastructure;

namespace VTaxi.Util
{
    public static class Services
    {
        public static StandardKernel Kernel { get; }

        static Services()
        {
            NinjectModule serviceModule = new ServiceModule(ConfigurationManager.ConnectionStrings["VTaxiDB"].ConnectionString);
            NinjectModule authenticationModule = new AuthenticationModule();
            NinjectModule orderModule = new OrderModule();
            Kernel = new StandardKernel(serviceModule, authenticationModule, orderModule);
        }
    }
}