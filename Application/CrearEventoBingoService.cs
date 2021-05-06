using Bingo.Domain;
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
    public class CrearEventoBingoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventoBingoRepository _eventoRepository;

        public CrearEventoBingoService(IUnitOfWork unitOfWork, IEventoBingoRepository eventoRepository)
        {
            _unitOfWork = unitOfWork;
            _eventoRepository = eventoRepository;
        }

        public DefaultResponse Ejecutar(CrearEventoBingoRequest request)
        {
            EventoBingo evento = new EventoBingo(request.Partidas, request.Fecha);
            _eventoRepository.Add(evento);
            _unitOfWork.Commit();
            return new DefaultResponse(0, $"Evento creado");
        }
    }

    public record CrearEventoBingoRequest(List<PartidaBingo> Partidas, DateTime Fecha);

}
