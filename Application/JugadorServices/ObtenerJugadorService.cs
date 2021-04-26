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
    public class ObtenerJugadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJugadorRepository _jugardorRepository;
        private IEmailSender _emailSender;

        public ObtenerJugadorService(IUnitOfWork unitOfWork, IEmailSender emailSender, IJugadorRepository jugardorRepository)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _jugardorRepository = jugardorRepository;
        }

        public ObtenerJugadorResponse GetxEmail(string email)
        {
            var jugadorconEmail = _jugardorRepository.FindFirstOrDefault(jugador => 
            jugador.Correo == email);

            if (jugadorconEmail == null)
            {
                return new ObtenerJugadorResponse(1, null);
            }
            else
            {
                return new ObtenerJugadorResponse(0, jugadorconEmail);
            }
        }
        public ObtenerJugadorResponse GetxId(string identi)
        {
            var jugadorconID = _jugardorRepository.FindFirstOrDefault(jugador =>
            jugador.Identificacion == identi);

            if (jugadorconID == null)
            {
                return new ObtenerJugadorResponse(1, null);
            }
            else
            {
                return new ObtenerJugadorResponse(0, jugadorconID);
            }
        }
    }

    public record ObtenerJugadorResponse(int estado, Jugador jugador);
}
