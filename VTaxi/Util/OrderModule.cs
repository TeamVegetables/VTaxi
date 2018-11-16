using Ninject.Modules;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;

namespace VTaxi.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}