using AutoMapper;
using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;
using RCE.Application.BusinessLogics;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Application.Services;
using RCE.Infrastructure.QueryServices;
using RCE.Infrastructure.Repositories;
using RCE.UI.Services;

namespace RCE.UI.App_Start
{
    public class ApplicationConfig
    {
        private static ILifetime Lifetime => new PerContainerLifetime();

        public static void Bootstrap(ServiceContainer container)
        {
            RegisterQueryServices(container);
            RegisterBusinessLogics(container);
            RegisterRepositories(container);
            RegisterServices(container);
            RegisterServiceFacades(container);
            RegisterMappers();

            IServiceLocator serviceLocator = new LightInjectServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        private static void RegisterQueryServices(ServiceContainer container)
        {
            container.Register<IProductQueryService, ProductQueryService>(Lifetime);
            container.Register<IProductTypeQueryService, ProductTypeQueryService>(Lifetime);
            container.Register<IUserQueryService, UserQueryService>(Lifetime);
        }

        private static void RegisterBusinessLogics(ServiceContainer container)
        {
            container.Register<IProductBusinessLogic, BaseProductBusinessLogic>(Lifetime);
            container.Register<IProductTypeBusinessLogic, BaseProductTypeBusinessLogic>(Lifetime);
            container.Register<IUserBusinessLogic, BaseUserBusinessLogic>(Lifetime);
        }

        private static void RegisterServices(ServiceContainer container)
        {
            container.Register<IProductService, ProductService>(Lifetime);
            container.Register<IProductTypeService, ProductTypeService>(Lifetime);
            container.Register<IUserService, UserService>(Lifetime);
        }

        private static void RegisterRepositories(ServiceContainer container)
        {
            container.Register<IProductRepository, ProductRepository>(Lifetime);
            container.Register<IProductTypeRepository, ProductTypeRepository>(Lifetime);
            container.Register<IUserRepository, UserRepository>(Lifetime);
        }

        private static void RegisterServiceFacades(ServiceContainer container)
        {
            container.Register<ProductServiceFacade>(Lifetime);
            container.Register<ProductTypeServiceFacade>(Lifetime);
            container.Register<UserServiceFacade>(Lifetime);
        }

        private static void RegisterMappers()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<Infrastructure.MapperProfile>();
                config.AddProfile<Application.MapperProfile>();
            });
        }

    }
}