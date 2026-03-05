using Core.EventBus;
using Core.Installers;

namespace Infrastructure.Core.Installers
{
    public class EventBusInstaller : Installer
    {
        public override void Install(ServiceLocator.ServiceLocator serviceLocator)
        {
            serviceLocator.RegisterService<IEventBus>(new Infrastructure.Core.EventBus.EventBus());
        }
    }
}