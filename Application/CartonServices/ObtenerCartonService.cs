using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;

namespace Bingo.Application.CartonServices
{
    public class ObtenerCartonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartonRepository _cartonRepository;
        private readonly IJugadorRepository _jugadorRepository;

        public ObtenerCartonService(IUnitOfWork unitOfWork, ICartonRepository cartonRepository, IJugadorRepository jugadorRepository)
        {
            _unitOfWork = unitOfWork;
            _cartonRepository = cartonRepository;
            _jugadorRepository = jugadorRepository;
        }

        public ObtenerCartonResponse Ejecutar(string JugadorId)
        {
            var jugador = _jugadorRepository.FindFirstOrDefault(jugador => jugador.Identificacion == JugadorId);
            if (jugador != null)
            {
                IEnumerable<Carton> cartones = _cartonRepository.FindBy((carton)=>carton.JugadorId == JugadorId);
                return new ObtenerCartonResponse(0, cartones);
            }

            return new ObtenerCartonResponse(1,Enumerable.Empty<Carton>());
        }
    }

    public record ObtenerCartonResponse(int estado, IEnumerable<Carton> Cartones);

}

