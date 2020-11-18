using aop;
using Autofac.Extras.DynamicProxy;
using System.Collections.Generic;

namespace MyWebServiceApi.Interfaces
{
    [Intercept(typeof(Logger))]
    public partial interface IWeatherService
    {

        IEnumerable<WeatherForecast> GetData();

        IEnumerable<WeatherForecast> GetData(IEnumerable<WeatherForecast> list, int param1, int param2);


    }
}
