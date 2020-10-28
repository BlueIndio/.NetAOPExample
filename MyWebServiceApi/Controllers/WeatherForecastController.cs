using aop;
using Microsoft.AspNetCore.Mvc;
using MyWebServiceApi.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherService myService;
        public WeatherForecastController(IWeatherService _myService)
        {
            myService = _myService ?? throw new ArgumentNullException(nameof(myService));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return myService.GetData();
        }
    }
}
