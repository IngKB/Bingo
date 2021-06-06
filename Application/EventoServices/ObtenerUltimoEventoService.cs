using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Domain.Contracts;
using Bingo.Domain.Entities;
using Bingo.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Bingo.Application.EventoServices
{
    public class ObtenerUltimoEventoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventoBingoRepository _eventoRepository;

        public ObtenerUltimoEventoService(IUnitOfWork unitOfWork, IEventoBingoRepository eventoRepository)
        {
            _unitOfWork = unitOfWork;
            _eventoRepository = eventoRepository;
        }

        public ObtenerUltimoEventoResponse Ejecutar()
        {
            EventoBingo evento =_eventoRepository.FindFirstOrDefault((evento) => evento.Estado == "Activo");
            if (evento!=null)
            {
                return new ObtenerUltimoEventoResponse(0, evento);
            }
            return new ObtenerUltimoEventoResponse(1, null);

        }
    }

    public record ObtenerUltimoEventoResponse(int Estado, EventoBingo Evento);
}
