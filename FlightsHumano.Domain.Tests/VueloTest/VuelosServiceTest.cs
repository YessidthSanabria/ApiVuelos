using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Domain.Services;
using FlightsHumano.Domain.Tests.VueloTest.DataBuilder;
using Moq;

namespace FlightsHumano.Domain.Tests.VueloTest
{
    public class VuelosServiceTest
    {


        private readonly Mock<IVueloRepository> _vueloRepositoryMock;
        private readonly Mock<IDestinoRepository> _destinoRepositoryMock;
        private readonly Mock<IOrigenRespository> _origenRepositoryMock;
        private readonly VuelosService _vueloService;

        public VuelosServiceTest()
        {
            _vueloRepositoryMock = new Mock<IVueloRepository>();
            _destinoRepositoryMock = new Mock<IDestinoRepository>();
            _origenRepositoryMock = new Mock<IOrigenRespository>();
            _vueloService = new VuelosService(_vueloRepositoryMock.Object, _destinoRepositoryMock.Object, _origenRepositoryMock.Object);
        }


        [Fact]
        public async Task ObtenerasTodosVuelos_RetornaListaTodoVueloDto()
        {

            var Vuelo1 = new VuelosBuilder()
                .WithId(1)
                .WithFechaLlegada(DateTime.Now)
                .WithFechaSalida(DateTime.Now.AddHours(2))
                .Build();

            var Vuelo2 = new VuelosBuilder()
                .WithId(2)
                .WithFechaLlegada(DateTime.Now.AddHours(1))
                .WithFechaSalida(DateTime.Now.AddHours(3))
                .Build();

            // Arrange
            var vuelosList = new List<Vuelos>
            {
               Vuelo1 , Vuelo2
            };


            _vueloRepositoryMock.Setup(x => x.ObtenerVuelos()).ReturnsAsync(vuelosList);

            _destinoRepositoryMock.Setup(x => x.ObtenerDestinosPorId(It.IsAny<Guid>()))
                .ReturnsAsync(new Destino { Id = Guid.NewGuid(), NombreDestino = "Destino 1" });

            _origenRepositoryMock.Setup(x => x.ObtenerOrigenPorId(It.IsAny<Guid>()))
                .ReturnsAsync(new Origen { Id = Guid.NewGuid(), NombreOrigen = "Origen 1" });


            // Act
            var result = await _vueloService.ObtenerasTodosVuelos();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);

            Assert.Equal(vuelosList[0].Id, result[0].Id);
            Assert.Equal("Origen 1", result[0].NombreOrigen);
            Assert.Equal("Destino 1", result[0].NombreDestino);
            Assert.Equal(vuelosList[0].FechaSalida, result[0].FechaSalida);
            Assert.Equal(vuelosList[0].FechaLlegada, result[0].FechaLlegada);

            Assert.Equal(vuelosList[1].Id, result[1].Id);
            Assert.Equal("Origen 1", result[1].NombreOrigen);
            Assert.Equal("Destino 1", result[1].NombreDestino);
            Assert.Equal(vuelosList[1].FechaSalida, result[1].FechaSalida);
            Assert.Equal(vuelosList[1].FechaLlegada, result[1].FechaLlegada);

            _vueloRepositoryMock.Verify(x => x.ObtenerVuelos(), Times.Once);
            _destinoRepositoryMock.Verify(x => x.ObtenerDestinosPorId(It.IsAny<Guid>()), Times.Exactly(2));
            _origenRepositoryMock.Verify(x => x.ObtenerOrigenPorId(It.IsAny<Guid>()), Times.Exactly(2));
        }
        [Fact]
        public async Task ObtenerVuelosPorId_RetornaTodoVueloDto()
        {
            // Arrange
            var vuelo = new VuelosBuilder()
             .WithId(1)
             .WithFechaLlegada(DateTime.Now)
             .WithFechaSalida(DateTime.Now.AddHours(2))
             .Build();       

            _vueloRepositoryMock.Setup(x => x.ObtenerVuelosPorId(It.IsAny<Guid>())).ReturnsAsync(vuelo);

            _destinoRepositoryMock.Setup(x => x.ObtenerDestinosPorId(It.IsAny<Guid>()))
                .ReturnsAsync(new Destino { Id = Guid.NewGuid(), NombreDestino = "Destino 1" });

            _origenRepositoryMock.Setup(x => x.ObtenerOrigenPorId(It.IsAny<Guid>()))
                .ReturnsAsync(new Origen { Id = Guid.NewGuid(), NombreOrigen = "Origen 1" });

            // Act
            var result = await _vueloService.ObtenerVuelosPorId(It.IsAny<Guid>());

            Assert.NotNull(result);           

            Assert.Equal(vuelo.Id, result.Id);
            Assert.Equal("Origen 1", result.NombreOrigen);
            Assert.Equal("Destino 1", result.NombreDestino);
            Assert.Equal(vuelo.FechaSalida, result.FechaSalida);
            Assert.Equal(vuelo.FechaLlegada, result.FechaLlegada);

            Assert.Equal(vuelo.Id, result.Id);
            Assert.Equal("Origen 1", result.NombreOrigen);
            Assert.Equal("Destino 1", result.NombreDestino);
            Assert.Equal(vuelo.FechaSalida, result.FechaSalida);
            Assert.Equal(vuelo.FechaLlegada, result.FechaLlegada);

            _vueloRepositoryMock.Verify(x => x.ObtenerVuelosPorId(It.IsAny<Guid>()), Times.Exactly(1));
            _destinoRepositoryMock.Verify(x => x.ObtenerDestinosPorId(It.IsAny<Guid>()), Times.Exactly(1));
            _origenRepositoryMock.Verify(x => x.ObtenerOrigenPorId(It.IsAny<Guid>()), Times.Exactly(1));

        }
    }
}
