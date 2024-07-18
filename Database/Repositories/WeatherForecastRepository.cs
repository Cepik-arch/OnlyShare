﻿using OnlyShare;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly DataContext _context;

    public WeatherForecastRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        return _context.WeatherForecasts
            .Select(wf => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(wf.Date),
                Summary = wf.Summary,
                TemperatureC = wf.TemperatureC
            });
    }
}