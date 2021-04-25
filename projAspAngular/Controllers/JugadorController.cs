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
    public class JugadorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJugadorRepository _JugadorRepository;
        private readonly IEmailSender _mailServer;
        public JugadorController
            (IUnitOfWork unitOfWork,
            IJugadorRepository cuentaBancariaRepository,
            IEmailSender mailServer)
        {

            _unitOfWork = unitOfWork;
            _JugadorRepository = cuentaBancariaRepository;
            _mailServer = mailServer;
        }



        [HttpPost]
        public DefaultResponse CrearJugador(CrearJugadorRequest request)
        {
            var service = new CrearJugadorService(_unitOfWork, _mailServer, _JugadorRepository);
            var response = service.Ejecutar(request);
            return response;
        }
    }
}
