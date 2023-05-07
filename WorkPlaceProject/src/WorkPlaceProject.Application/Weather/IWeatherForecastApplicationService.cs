namespace WorkPlaceProject.Application.Weather
{
    public interface IWeatherForecastApplicationService
    {
        Task<WeatherForecastAdto[]> GetForecastAsync(DateTime startDate);
    }
}
