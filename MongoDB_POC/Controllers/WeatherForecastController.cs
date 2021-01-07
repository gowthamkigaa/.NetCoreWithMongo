using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB_POC.Models;
using MongoDB_POC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_POC.Controllers
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
        private readonly BookService _bookService;
        public WeatherForecastController(BookService bookService, ILogger<WeatherForecastController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.Get();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
