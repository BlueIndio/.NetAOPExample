using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebServiceApi.Interfaces;

namespace MyWebServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IMyService myService;
        public WeatherForecastController(IMyService _myService)
        {
            myService = _myService ?? throw new ArgumentNullException(nameof(myService));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return myService.GetData();
        }
    }
}
