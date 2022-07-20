using Application.WeatherForecasts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlazorwasmCleanArchitecture.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}