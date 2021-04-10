using Bingo.Domain;
using Bingo.Domain.Contracts;
using System;

namespace Application
{
    public class CrearCartonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearCartonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearCartonResponse Ejecutar(CrearCartonRequest request)
        {

            Carton carton = new Carton();
            return new CrearCartonResponse() { Mensaje = "Carton registrado"};
        }


    }
    public class CrearCartonResponse
    {
        public string Mensaje { get; set; }
    }

    public class CrearCartonRequest
    { 
        public string JugadorID { get; set; }
    }
}
