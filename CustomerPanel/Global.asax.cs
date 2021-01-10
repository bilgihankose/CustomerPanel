using Autofac;
using Autofac.Integration.Mvc;
using CustomerPanel.Context;
using CustomerPanel.Repository;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomerPanel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CafeManagementContext>()
                .InstancePerRequest();


            builder.RegisterType<CafeRepository>().As<ICafeRepository>()
                .InstancePerRequest();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
              .InstancePerRequest();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
