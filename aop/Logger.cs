using Castle.DynamicProxy;
using System;
using System.IO;
using System.Linq;

namespace aop
{
    public class Logger : IInterceptor
    {
        readonly TextWriter writer;

        public Logger(TextWriter textWriter)
        {
            writer = textWriter ?? throw new ArgumentNullException(nameof(writer));
        }
        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var args = string.Join(" ", invocation.Arguments.Select(a => (a ?? string.Empty).ToString()));

            writer.WriteLine($"Calling: {name}");
            writer.WriteLine($"Args: {args}");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed(); //Intercepted method is executed here.
            watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;

            writer.WriteLine($"Done: result was {invocation.ReturnValue}");
            writer.WriteLine($"Execution Time: {executionTime} ms.");
            writer.WriteLine();

        }
    }
}
