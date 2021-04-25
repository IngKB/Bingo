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
        private IEmailSender _emailSender;

        public CrearJugadorService(IUnitOfWork unitOfWork, IEmailSender emailSender, IJugadorRepository jugardorRepository)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _jugardorRepository = jugardorRepository;
        }

        public DefaultResponse Ejecutar(CrearJugadorRequest request)
        {
            var jugador = _jugardorRepository.FindFirstOrDefault(jugador => jugador.Identificacion == request.jugador.Identificacion);
            if (jugador == null)
            {
                var newJugador = request.jugador;

                _jugardorRepository.Add(newJugador);
                _unitOfWork.Commit();
                return new DefaultResponse(0, $"Bienvenido {newJugador.Primer_Nombre}");
            }
            else
            {
                return new DefaultResponse(0,$"El Jugador ya se encuentra registrado");
            }
        }
    }
    public record CrearJugadorRequest(Jugador jugador);

    public record DefaultResponse(int estado, string mensaje);

}
