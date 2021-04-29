using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;

namespace Bingo.Application
{
    public class LoginUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJugadorRepository _jugadorRepository;
        private IEmailSender _emailSender;

        public LoginUsuarioService(IUnitOfWork unitOfWork, IEmailSender emailSender, IUsuarioRepository usuarioRepository, IJugadorRepository jugadorRepository)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _usuarioRepository = usuarioRepository;
            _jugadorRepository = jugadorRepository;
        }

        public LoginUsuarioResponse Ejecutar(LoginUsuarioRequest request)
        {
            try { 
            var usuario = _usuarioRepository.FindFirstOrDefault(user => user.UserName == request.Usuario.UserName);

            if (usuario == null)
            {
                return new LoginUsuarioResponse(1,"El nombre de usuario no existe", null);
            }
            else if(usuario.Password != request.Usuario.Password)
            {
                return new LoginUsuarioResponse(2,"La contraseña no coincide con el usuario", null);
            }
            else
            {
                Jugador jugador =_jugadorRepository.FindFirstOrDefault(jugador => jugador.Identificacion == usuario.JugadorId);
                return new LoginUsuarioResponse(0, $"Bienvenido {usuario.UserName}",jugador);
            }
            }
            catch (Exception e)
            {
                return new LoginUsuarioResponse(1, $"Error", null);
            }
        }
    }

    public record LoginUsuarioResponse(int Estado, string Mensaje, Jugador Jugador );
    public record LoginUsuarioRequest(Usuario Usuario);
}
