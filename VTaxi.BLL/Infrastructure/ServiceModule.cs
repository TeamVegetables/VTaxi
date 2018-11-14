using Ninject.Modules;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Repositories;

namespace VTaxi.BLL.Infrastructure
{
    /// <summary>
    /// Class which load data from database
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        /// <summary>
        /// Constructor of ServiceModule
        /// </summary>
        /// <param name="connection">string to connect</param>
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        /// <summary>
        /// Loading data
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
