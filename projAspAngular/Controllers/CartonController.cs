using Bingo.Application;
using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartonRepository _cartonRepository;
        private readonly IEventoBingoRepository _eventoBingoRepository;
        private readonly IJugadorRepository _jugadorRepository;
        public CartonController
            (IUnitOfWork unitOfWork,
            ICartonRepository cuentaBancariaRepository,
            IEventoBingoRepository eventoBingoRepository,
            IJugadorRepository jugadorRepository
            )
        {

            _unitOfWork = unitOfWork;
            _cartonRepository = cuentaBancariaRepository;
            _eventoBingoRepository = eventoBingoRepository;
            _jugadorRepository = jugadorRepository;
        }



        [HttpPost]
        public DefaultResponse CrearCarton(ComprarCartonRequest request)
        {
            var service = new ComprarCartonService(_unitOfWork, _cartonRepository, _jugadorRepository, _eventoBingoRepository);
            var response = service.Ejecutar(request);
            return response;
        }
    }
}
