using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using Bingo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Application
{
    public class ComprarCartonService
    {
        // El metodo ejecutar recibe un carton, y el Id del jugador 
        // Le asigna el id del jugador al carton    => carton.jugadorid = jugadorId

        //luego si lo agrega a la base de datos, hace commit y to' listo
        // luego agregar el metodo en la api (es un Post)  private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartonRepository _cartonRepository;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly IEventoBingoRepository _eventoRepository;

        public ComprarCartonService(IUnitOfWork unitOfWork, ICartonRepository cartonRepository, IJugadorRepository jugadorRepository, IEventoBingoRepository eventoBingoRepository)
        {
            _unitOfWork = unitOfWork;
            _cartonRepository = cartonRepository;
            _jugadorRepository = jugadorRepository;
            _eventoRepository = eventoBingoRepository;
        }

        public DefaultResponse Ejecutar(ComprarCartonRequest request)
        {
            var jugador = _jugadorRepository.FindFirstOrDefault(jugador => jugador.Identificacion == request.Carton.JugadorId);
            var evento = _eventoRepository.FindFirstOrDefault(evento => evento.Id == request.Carton.EventoId);

            if (jugador != null && evento != null && request.Carton.Casillas != null)
            {
                _cartonRepository.Add(request.Carton);
                _unitOfWork.Commit();
                return new DefaultResponse(0, "Carton comprado");
            }

            return new DefaultResponse(1, "Carton vacio " + request.Carton.JugadorId + " " + request.Carton.EventoId);
        }
    }

    public record ComprarCartonRequest(Carton Carton);
}
