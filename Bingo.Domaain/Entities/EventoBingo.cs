using Bingo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo.Domain.Entities
{
    public class EventoBingo: Entity<int>, IAggregateRoot
    {
        public List<PartidaBingo> Partidas { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public string Estado { get; private set; }

        public EventoBingo(List<PartidaBingo> partidas, DateTime fechaInicio)
        {
            Partidas = partidas;
            FechaInicio = fechaInicio;
            Estado = "Activo";
        }

        public EventoBingo()
        {
        }
    }

}
