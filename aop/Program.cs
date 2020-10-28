using System;

namespace aop
{
    class Program
    {
        static void Main(string[] args)
        {
         
            FactoryLogger fc = new FactoryLogger();

            fc.AddType<Calculator, ICalculator>();

            fc.GenerateServiceProvider();

            var willBeIntercepted = fc.GetResolved<ICalculator>();

            willBeIntercepted.Divide(1, 0);


            Console.ReadLine();
        }
    }
}
