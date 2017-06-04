using System.Web.Http.Dependencies;
using Ninject;
using Prospa.Web;

namespace Fornax.DotNet.Fornax.IOC.Ninject.Http
{
    public class NinjectDependencyResolverHttp : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolverHttp(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel.BeginBlock());
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}