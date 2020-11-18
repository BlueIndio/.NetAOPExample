using aop;
using MyWebServiceApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebServiceApi.Services
{
    public partial class WeatherService : IWeatherService
    {
        public IEnumerable<WeatherForecast> GetData()
        {
            throw new Exception();
        }

        public IEnumerable<WeatherForecast> GetData(IEnumerable<WeatherForecast> list, int param1, int param2)
        {

            list.ToList()[param1].Date.AddDays(param2);

            return list;
        }
    }
}
