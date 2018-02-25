[assembly: WebActivator.PreApplicationStartMethod(typeof(Cheque.Writing.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Cheque.Writing.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace Cheque.Writing.WebAPI.App_Start
{
    using System;
    using System.Web;
    using Cheque.Writing.App.Business.Components;
    using Cheque.Writing.App.Business.Interfaces;
    using Cheque.Writing.Common;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Cheque.Writing.Common.Logger;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.WebApi.DependencyResolver;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
           
            RegisterServices(kernel);
            // Set Web API Resolver
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICheckqueTranslator>().To<ChecqueTranslatorComponent>();
            kernel.Bind<ILogger>().To<ServiceFileLogger>();
                      
        }        
    }
}
