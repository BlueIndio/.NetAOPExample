using System;

namespace aop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var builder = new ContainerBuilder();

            //builder.RegisterType<Calculator>()
            //    .As<ICalculator>()
            //    .EnableInterfaceInterceptors();
            //    //.InterceptedBy(typeof(Logger));

            // Name registration
            // builder.Register(i => new Logger(Console.Out))
            //    .Named<IInterceptor>("log-calls");

            // Typed registration
            //builder.Register(c => new Logger(Console.Out));

            //var container = builder.Build();

            //var willBeIntercepted = container.Resolve<ICalculator>();

            FactoryLogger fc = new FactoryLogger();

            fc.AddType<Calculator, ICalculator>();

            fc.GenerateServiceProvider();

            var willBeIntercepted = fc.GetResolved<ICalculator>();

            willBeIntercepted.Divide(1, 0);


            Console.ReadLine();
        }
    }
}
