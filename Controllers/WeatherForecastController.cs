using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyShare;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastRepository _repository;

    public WeatherForecastController(IWeatherForecastRepository repository)
    {
        _repository = repository;
    }

    [Authorize]
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _repository.GetWeatherForecasts();
    }
}