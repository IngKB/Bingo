using Bingo.Application;
using Bingo.Application.EventoServices;
using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventoBingoRepository _eventoRepository;

        public EventoController(IUnitOfWork unitOfWork, IEventoBingoRepository eventoRepository)
        {
            _unitOfWork = unitOfWork;
            _eventoRepository = eventoRepository;
        }

        [HttpPost]
        public DefaultResponse CrearEvento(CrearEventoBingoRequest request)
        {
            var service = new CrearEventoBingoService(_unitOfWork, _eventoRepository);
            var response = service.Ejecutar(request);
            return response;
        }

        [HttpGet]
        public ObtenerUltimoEventoResponse ObtenerEvento()
        {
            var service = new ObtenerUltimoEventoService(_unitOfWork, _eventoRepository);
            var response = service.Ejecutar();
            return response;
        }
    }
}
