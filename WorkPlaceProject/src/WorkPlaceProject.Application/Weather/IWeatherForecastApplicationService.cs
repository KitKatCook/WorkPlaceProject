using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceProject.Domain;

namespace WorkPlaceProject.Application.Weather
{
    public interface IWeatherForecastApplicationService
    {
        Task<WeatherForecastAdto[]> GetForecastAsync(DateTime startDate);
    }
}
