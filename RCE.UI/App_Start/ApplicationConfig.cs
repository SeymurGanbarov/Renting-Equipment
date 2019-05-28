using LightInject;

namespace RCE.UI.App_Start
{
    public class ApplicationConfig
    {
        private static ILifetime Lifetime => new PerScopeLifetime();

        public static void BootstrapContainer(ServiceContainer container)
        {
            RegisterBusinessLogics(container);
            RegisterServices(container);
        }

        public static void RegisterBusinessLogics(ServiceContainer container)
        {

        }

        public static void RegisterServices(ServiceContainer container)
        {

        }

    }
}