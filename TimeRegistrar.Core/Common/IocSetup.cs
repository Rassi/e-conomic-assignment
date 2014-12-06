using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace TimeRegistrar.Core.Common
{
    public class IocSetup : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}