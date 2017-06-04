using System.Reflection;
using System.Web.Http;
using Fornax.DotNet.Fornax.IOC.Ninject.Http;
using Ninject;
using Prospa.Core;
using Prospa.Core.Interface;

namespace Prospa.Web
{
    public class IocConfig
    {
        public static void RegisterIocContainer(HttpConfiguration config)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IChequeService>().To<ChequeService>();

            config.DependencyResolver = new NinjectDependencyResolverHttp(kernel);
        }
    }
}