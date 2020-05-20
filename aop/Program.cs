using Autofac;
using Autofac.Extras.DynamicProxy;
using System;

namespace aop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ContainerBuilder();

            builder.RegisterType<Calculator>()
                .As<ICalculator>()
                .EnableInterfaceInterceptors();
                //.InterceptedBy(typeof(Logger));

            // Name registration
            //builder.Register(i => new Logger(Console.Out))
            //    .Named<IInterceptor>("log-calls");

            // Typed registration
            builder.Register(c => new Logger(Console.Out));

            var container = builder.Build();

            var willBeIntercepted = container.Resolve<ICalculator>();

            willBeIntercepted.Add(4, 5);


            Console.ReadLine();
        }
    }
}
