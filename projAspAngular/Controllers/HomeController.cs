using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Trabajando!!";
        }
    }
}
