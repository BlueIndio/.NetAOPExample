using Autofac;
using Autofac.Extras.DynamicProxy;
using System;

namespace aop
{
    public partial class FactoryLogger
    {
        public ContainerBuilder Builder { get; set; }

        private IContainer container;

        public FactoryLogger()
        {
            Builder = new ContainerBuilder();

            Builder.Register(c => new Logger(Console.Out));
        }

        public void AddType<TClass, TInterface>()
        {
            Builder.RegisterType<TClass>()
                    .As<TInterface>()
                    .EnableInterfaceInterceptors();
        }

        public void GenerateServiceProvider()
        {
            container = Builder.Build();

        }

        public TService GetResolved<TService>() where TService : notnull
        {
            return container.Resolve<TService>();
        }
    }
}
