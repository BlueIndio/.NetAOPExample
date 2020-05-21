using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace aop
{
    public partial class FactoryLogger
    {
        private readonly ContainerBuilder builder;

        private IContainer container;

        public FactoryLogger()
        {
            builder = new ContainerBuilder();

            builder.Register(c => new Logger(Console.Out));
        }

        public void AddType<TClass, TInterface>() 
        {
            builder.RegisterType<TClass>()
                    .As<TInterface>()
                    .EnableInterfaceInterceptors();   
        }

        public void GenerateContainer() 
        {
            container = builder.Build();
        }

        public TService GetResolved<TService>() where TService : notnull
        {
            return container.Resolve<TService>();
        }
    }
}
