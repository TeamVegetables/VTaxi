using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Repositories;

namespace VTaxi.BLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string ConnectionString;

        public ServiceModule(string connection)
        {
            ConnectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(ConnectionString);
        }
    }
}
