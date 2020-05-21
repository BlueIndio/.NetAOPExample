using Autofac.Extras.DynamicProxy;

namespace aop
{
    // This attribute will look for a TYPED
    // interceptor registration:
    [Intercept(typeof(Logger))]
    public interface ICalculator
    {
        int Add(int a, int b);

        int Divide(int a, int b);
    }
    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Divide(int a, int b)
        {
            return a / b;   
        }
    }
}
