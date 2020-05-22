using aop;
using Autofac.Extras.DynamicProxy;
using System.Collections.Generic;

namespace MyWebServiceApi.Interfaces
{
    [Intercept(typeof(Logger))]
    public partial interface IMyService
    {

        IEnumerable<WeatherForecast> GetData();


    }
}
