using System.Collections.Generic;

namespace MyWebServiceApi.Interfaces
{
    public partial interface IMyService
    {

        IEnumerable<WeatherForecast> GetData();


    }
}
