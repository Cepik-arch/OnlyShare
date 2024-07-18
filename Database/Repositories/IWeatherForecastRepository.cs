using OnlyShare;

public interface IWeatherForecastRepository
{
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}