﻿using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ProjectManagement.AspNetMvc.PL;
using ProjectManagement.AspNetMvc.PL.Infrastructure;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace ProjectManagement.AspNetMvc.PL
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}