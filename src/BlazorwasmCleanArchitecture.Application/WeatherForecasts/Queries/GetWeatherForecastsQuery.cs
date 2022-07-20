using MediatR;

namespace Application.WeatherForecasts.Queries;

public record GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>;