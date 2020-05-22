using Castle.DynamicProxy;
using System;
using System.IO;
using System.Linq;

namespace aop
{
    public class Logger : IInterceptor
    {
        readonly TextWriter writer;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Logger(TextWriter textWriter)
        {
            writer = textWriter ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Intercept(IInvocation invocation)
        {
            var name = string.Empty;
            var args = string.Empty;
            try
            {
                name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
                args = string.Join(" ", invocation.Arguments.Select(a => (a ?? string.Empty).ToString()));

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
            catch (Exception ex)
            {
                writer.WriteLine($"Exception: result was {ex.Message}");
                var rng = new Random();

                invocation.ReturnValue = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray();
            }


        }
    }
}
