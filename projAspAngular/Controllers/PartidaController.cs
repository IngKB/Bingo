using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocket.HubConfig;

namespace WebSocket.Controllers
{
    [Route("api/numerosActuales")]
    [ApiController]
    public class PartidaController : Controller
    {
        private IHubContext<PartidaHub> _hub;
        private IEnumerable<int> numeros;

        public PartidaController(IHubContext<PartidaHub> hub)
        {
            _hub = hub;
            numeros = Enumerable.Range(1, 25);
        }
        [HttpGet]
        public IActionResult Get()
        {
            _hub.Clients.All.SendAsync("numeromarcado", numeros);
            return Ok(new { Message = "Request Completed" });
        }

    }
}
