using aop;
using MyWebServiceApi.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebServiceApi.Services
{
    public partial class WeatherService : IWeatherService
    {
        public IEnumerable<WeatherForecast> GetData()
        {
            throw new Exception();
        }
    }
}
