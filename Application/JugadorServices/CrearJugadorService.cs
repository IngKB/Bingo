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
        private readonly IJugadorRepository _jugadorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private IEmailSender _emailSender;

        public CrearJugadorService(IUnitOfWork unitOfWork, IEmailSender emailSender, IUsuarioRepository usuarioRepository, IJugadorRepository jugardorRepository)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _jugadorRepository = jugardorRepository;
            _usuarioRepository = usuarioRepository;

        }

        public CrearJugadorResponse Ejecutar(CrearJugadorRequest request)
        {
            var jugadorconID = _jugadorRepository.FindFirstOrDefault(jugador => jugador.Identificacion == request.Jugador.Identificacion);
            var jugadorconEmail = _jugadorRepository.FindFirstOrDefault(jugador => jugador.Correo == request.Jugador.Correo);
            
            if(jugadorconID != null)
            {
                return new CrearJugadorResponse(1, $"Identificación ya se encuentra registrada",null);
            }else if(jugadorconEmail != null)
            {
                return new CrearJugadorResponse(2, $"Correo ya se encuentra registrado",null);
            }
            else
            {
                var newJugador = request.Jugador;
                var usuario = new Usuario(newJugador.Correo, request.Usuario.Password, newJugador.Identificacion);
                _jugadorRepository.Add(newJugador);
                _usuarioRepository.Add(usuario);
                _unitOfWork.Commit();
                return new CrearJugadorResponse(0, $"Bienvenido {newJugador.Primer_Nombre}", newJugador);
            }
        }
    }
    public record CrearJugadorRequest(Jugador Jugador, Usuario Usuario);
    public record CrearJugadorResponse(int Estado, string Mensaje, Jugador Jugador);
}
