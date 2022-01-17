using Microsoft.AspNetCore.Mvc;
using moto_shop_test.DAL;

namespace moto_shop_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost(Name = "AddWeatherForecast")]
        public IActionResult AddWeatherForecast()
        {
            try
            {
                WeatherForecast weatherForecast = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(Random.Shared.Next(1, 31)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
                _db.WeatherForecasts.Add(weatherForecast);
                _db.SaveChanges();
                return Ok(weatherForecast);

            }
            catch (Exception)
            {
                return BadRequest("Not added");
            }

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}