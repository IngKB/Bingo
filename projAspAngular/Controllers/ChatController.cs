using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using projAspAngular.hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projAspAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub> _hub;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public ChatController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var timerManager = new TimeManager(() => _hub.Clients.All.SendAsync("transfertabledata", DummieData()));
            return Ok(new { Message = "Request Completed" });
        }

        private IEnumerable<WeatherForecast> DummieData()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
