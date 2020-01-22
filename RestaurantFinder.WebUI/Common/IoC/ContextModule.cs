using Autofac;
using System.Linq;
using System.Reflection;

namespace RestaurantFinder.WebUI.Common.IoC
{
    public class ContextModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(Assembly.Load("RestaurantFinder.Repository")
                .GetExportedTypes()
                .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                .Where(x => x.Name.EndsWith("Context")).ToArray())
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}