using System;
using System.Configuration;
using Ninject;
using Ninject.Modules;
using VTaxi.BLL.Infrastructure;

namespace VTaxi.Util
{
    public static class Services
    {
        static Services()
        {
            NinjectModule serviceModule;
            try
            {
                serviceModule =
                    new ServiceModule(ConfigurationManager.ConnectionStrings["VTaxiDBAzure"].ConnectionString);
            }
            catch (Exception)
            {
                serviceModule =
                    new ServiceModule(ConfigurationManager.ConnectionStrings["VTaxiDB"].ConnectionString);
            }
            NinjectModule authenticationModule = new AuthenticationModule();
            NinjectModule orderModule = new OrderModule();
            Kernel = new StandardKernel(serviceModule, authenticationModule, orderModule);
        }

        public static StandardKernel Kernel { get; }
    }
}