using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;

namespace RCE.UI.App_Start
{
    public class ApplicationConfig
    {
        private static ILifetime Lifetime => new PerContainerLifetime();

        public static void Bootstrap(ServiceContainer container)
        {
            RegisterBusinessLogics(container);
            RegisterServices(container);

            IServiceLocator serviceLocator = new LightInjectServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public static void RegisterQueryServices(ServiceContainer container)
        {

        }

        public static void RegisterBusinessLogics(ServiceContainer container)
        {

        }

        public static void RegisterServices(ServiceContainer container)
        {

        }

        public static void RegisterRepositories(ServiceContainer container)
        {

        }

    }
}