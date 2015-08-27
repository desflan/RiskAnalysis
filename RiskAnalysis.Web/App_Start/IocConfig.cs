using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace RiskAnalysis.Web.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IStartable).IsAssignableFrom(t))
                .As<IStartable>()
                .SingleInstance();

            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}