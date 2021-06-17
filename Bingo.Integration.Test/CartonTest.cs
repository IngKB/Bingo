using Bingo.Application;
using Bingo.Domain.Entities;
using Bingo.Infraestructura.ObjectMother;
using Bingo.Integration.Test.Base;
using FluentAssertions;
using Newtonsoft.Json;
using projAspAngular;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bingo.Integration.Test
{
    public class CartonTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;
        public CartonTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task PuedeComprarCartonTestAsync()
        {
            Carton carton = CartonMother.CrearCarton(1, "0001");
            
            var request = new ComprarCartonRequest(carton);
            
            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var httpClient = _factory.CreateClient();
            var context = _factory.CreateContext();
            context.Jugadores.Add(JugadorMother.CrearJugador("0001"));
            context.Eventos.Add(new EventoBingo());
            context.SaveChanges();

            var responseHttp = await httpClient.PostAsync("api/Carton", content);
            responseHttp.StatusCode.Should().Be(HttpStatusCode.OK);
            var respuesta = await responseHttp.Content.ReadAsStringAsync();
            respuesta.Should().Contain($"Carton comprado");
            
        }
    }
}
