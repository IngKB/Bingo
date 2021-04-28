using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Application
{
    public class CrearJugadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJugadorRepository _jugardorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private IEmailSender _emailSender;

        public CrearJugadorService(IUnitOfWork unitOfWork, IEmailSender emailSender, IUsuarioRepository usuarioRepository, IJugadorRepository jugardorRepository)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _jugardorRepository = jugardorRepository;
            _usuarioRepository = usuarioRepository;

        }

        public DefaultResponse Ejecutar(CrearJugadorRequest request)
        {
            var jugadorconID = _jugardorRepository.FindFirstOrDefault(jugador => jugador.Identificacion == request.Jugador.Identificacion);
            var jugadorconEmail = _jugardorRepository.FindFirstOrDefault(jugador => jugador.Correo == request.Jugador.Correo);
            
            if(jugadorconID != null)
            {
                return new DefaultResponse(1, $"Identificación ya se encuentra registrada");
            }else if(jugadorconEmail != null)
            {
                return new DefaultResponse(2, $"Correo ya se encuentra registrado");
            }
            else
            {
                var newJugador = request.Jugador;
                var usuario = new Usuario(newJugador.Correo, request.Usuario.Password, newJugador.Identificacion);
                _jugardorRepository.Add(newJugador);
                _usuarioRepository.Add(usuario);
                _unitOfWork.Commit();
                return new DefaultResponse(0, $"Bienvenido {newJugador.Primer_Nombre}");
            }
        }
    }
    public record CrearJugadorRequest(Jugador Jugador, Usuario Usuario);

}
