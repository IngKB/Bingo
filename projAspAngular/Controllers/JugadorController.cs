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
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IEmailSender _mailServer;
        public JugadorController
            (IUnitOfWork unitOfWork,
            IJugadorRepository jugadorRepository,
            IUsuarioRepository usuarioRepository,
            IEmailSender mailServer)
        {

            _unitOfWork = unitOfWork;
            _JugadorRepository = jugadorRepository;
            _UsuarioRepository = usuarioRepository;
            _mailServer = mailServer;
        }



        [HttpPost]
        public CrearJugadorResponse CrearJugador(CrearJugadorRequest request)
        {
            var service = new CrearJugadorService(_unitOfWork, _mailServer, _UsuarioRepository, _JugadorRepository);
            var response = service.Ejecutar(request);
            return response;
        }

        [HttpGet("/id/{id}")]
        public ObtenerJugadorResponse ObtenerJugadorxId(string id)
        {
            var service = new ObtenerJugadorService(_unitOfWork, _mailServer, _JugadorRepository);
            var response = service.GetxId(id);
            return response;
        }

        [HttpGet("/email/{email}")]
        public ObtenerJugadorResponse ObtenerJugadorxEmail(string email)
        {
            var service = new ObtenerJugadorService(_unitOfWork, _mailServer, _JugadorRepository);
            var response = service.GetxEmail(email);
            return response;
        }
    }
}
