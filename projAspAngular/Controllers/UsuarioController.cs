using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bingo.Application;
using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebSocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IJugadorRepository _JugadorRepository;
        private readonly IEmailSender _mailServer;
        public UsuarioController
            (IUnitOfWork unitOfWork,
            IJugadorRepository jugadorRepository,
            IUsuarioRepository usuarioRespository,
            IEmailSender mailServer)
        {

            _unitOfWork = unitOfWork;
            _JugadorRepository = jugadorRepository;
            _mailServer = mailServer;
        }


        [HttpPost]
        public LoginUsuarioResponse LoginUsuario(LoginUsuarioRequest request)
        {
            var service = new LoginUsuarioService(_unitOfWork, _mailServer, _UsuarioRepository, _JugadorRepository);
            var response = service.Ejecutar(request);
            return response;
        }
    }
}
