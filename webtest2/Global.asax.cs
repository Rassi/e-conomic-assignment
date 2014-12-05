using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Extensions.Conventions;
using TimeRegistrar.Core.Data;

namespace webtest2
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var kernel = new StandardKernel();
            kernel.Bind(x => x
                .FromThisAssembly() // Scans currently assembly
                .SelectAllClasses() // Retrieve all non-abstract classes
                .BindDefaultInterface());

            kernel.Bind(x => x
                .FromAssembliesMatching("TimeRegistrar*") // Scans currently assembly
                .SelectAllClasses() // Retrieve all non-abstract classes
                .BindDefaultInterface());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var dbSetup = new DbSetup(kernel.Get<IDbContext>());
            dbSetup.SetupDatabase();
        }
    }
}
