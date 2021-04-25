using Bingo.Domain.Entities;
using Bingo.Domain.Contracts;
using System;
using Bingo.Domain.Repositories;

namespace Bingo.Application
{
    public class CrearCartonService
    {

        public CrearCartonService()
        {
            
        }

        public CrearCartonResponse Ejecutar()
        {
            Carton carton = new Carton();
            return new CrearCartonResponse(0, carton);
        }

    }
    public record CrearCartonResponse(int estado, Carton carton);
    
}
