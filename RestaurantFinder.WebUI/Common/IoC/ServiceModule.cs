using Autofac;
using RestaurantFinder.WebUI.Common.logger;
using System.Linq;
using System.Reflection;

namespace RestaurantFinder.WebUI.Common.IoC
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(LoggerFacade<>)).As(typeof(ILoggerFacade<>));

            builder.RegisterTypes(Assembly.Load("RestaurantFinder.BusinessLogic")
                .GetExportedTypes()
                .Where(x => x.Name.EndsWith("Service")).ToArray())
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}