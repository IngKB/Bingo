using Bingo.Application;
using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartonRepository _cartonRepository;
        private readonly IEmailSender _mailServer;
        public CartonController
            (IUnitOfWork unitOfWork,
            ICartonRepository cuentaBancariaRepository,
            IEmailSender mailServer)
        {

            _unitOfWork = unitOfWork;
            _cartonRepository = cuentaBancariaRepository;
            _mailServer = mailServer;
        }



        [HttpGet]
        public CrearCartonResponse CrearCarton()
        {
            var service = new CrearCartonService();
            var response = service.Ejecutar();
            return response;
        }
    }
}
