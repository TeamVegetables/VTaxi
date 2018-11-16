using Ninject.Modules;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;

namespace VTaxi.Util
{
    public class AuthenticationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticationService>().To<AuthenticationService>();
        }
    }
}