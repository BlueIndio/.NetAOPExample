using aop;
using MyWebServiceApi.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebServiceApi
{
    public partial class MyService : IMyService
    {
        public IEnumerable<WeatherForecast> GetData()
        {
            throw new Exception();
        }
    }
}
