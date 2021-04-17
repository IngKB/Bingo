using Bingo.Domain.Entities;
using Bingo.Domain.Contracts;
using System;
using Bingo.Domain.Repositories;

namespace Bingo.Application
{
    public class CrearCartonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartonRepository _cartonRepository;
        private IEmailSender _emailSender;

        public CrearCartonService(IUnitOfWork unitOfWork, IEmailSender emailSender, ICartonRepository cartonRepository)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _cartonRepository = cartonRepository;
        }

        public CrearCartonResponse Ejecutar(CrearCartonRequest request)
        {

            Carton carton = new Carton(request.JugadorID);
            _cartonRepository.Add(carton);
            _unitOfWork.Commit();

            //aqui se mandaria correo al jugador
            var result = _emailSender.SendEmailAsync("karlosmario0123@gmail.com", "Carton comprado", $"Usted a comprado el carton numero {carton.Id}");
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
