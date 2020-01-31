using Autofac;
using System.Linq;
using System.Reflection;

namespace RestaurantFinder.WebUI.Common.IoC
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(Assembly.Load("RestaurantFinder.Repository")
                .GetExportedTypes()
                .Where(x => x.Name.EndsWith("Repository")).ToArray())
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}