using FlightsHumano.Domain.Dtos;
using FlightsHumano.Domain.Entities;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Domain.Services;
using FlightsHumano.Domain.Tests.ReservaTest.DataBuilder;
using Moq;

namespace FlightsHumano.Domain.Tests.ReservaTest
{
    public class ReservaServiceTest
    {
        private readonly Mock<IReservaRepository> _reservaRepositoryMock;
        private readonly ReservaService _reservaService;
        public ReservaServiceTest()
        {
            _reservaRepositoryMock = new Mock<IReservaRepository>();
            _reservaService = new ReservaService(_reservaRepositoryMock.Object);
        }



        [Fact]
        public async Task ObtenerTodasReservas_ReturnaListaReservas()
        {
            // Arrange
            var reserva1 = new ReservaBuilder().WithIdReserva(1).WithNombreUsuario("Usuario 1").WithMailUsuario("Usuario1@mail.com").Build();
            var reserva2 = new ReservaBuilder().WithIdReserva(2).WithNombreUsuario("Usuario 2").WithMailUsuario("Usuario2@mail.com").Build();
            var reservasList = new List<Reserva> { reserva1, reserva2 };

            _reservaRepositoryMock.Setup(x => x.ObtenerReservas()).ReturnsAsync(reservasList);

            // Act
            var result = await _reservaService.ObtenerTodasReservas();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, ((List<Reserva>)result).Count);

            var resultList = new List<Reserva>(result);
            Assert.Equal(reserva1.Id, resultList[0].Id);
            Assert.Equal(reserva1.NombreUsuario, resultList[0].NombreUsuario);
            Assert.Equal(reserva1.MailUsuario, resultList[0].MailUsuario);

            Assert.Equal(reserva2.Id, resultList[1].Id);
            Assert.Equal(reserva2.NombreUsuario, resultList[1].NombreUsuario);
            Assert.Equal(reserva2.MailUsuario, resultList[1].MailUsuario);

            _reservaRepositoryMock.Verify(x => x.ObtenerReservas(), Times.Once);
        }

        [Fact]
        public async Task ObtenerReservaPorId_ReturnaReservas()
        {
            // Arrange
            var reserva = new ReservaBuilder().WithIdReserva(1).WithNombreUsuario("Usuario 1").WithMailUsuario("Usuario1@mail.com").Build();

            _reservaRepositoryMock.Setup(x => x.ObtenerReservasPorId(It.IsAny<Guid>())).ReturnsAsync(reserva);

            // Act
            var result = await _reservaService.ObtenerReservasPorId(It.IsAny<Guid>());

            // Assert
            Assert.NotNull(result);

            Assert.Equal(reserva.Id, result.Id);
            Assert.Equal(reserva.NombreUsuario, result.NombreUsuario);
            Assert.Equal(reserva.MailUsuario, result.MailUsuario);

            Assert.Equal(reserva.Id, result.Id);
            Assert.Equal(reserva.NombreUsuario, result.NombreUsuario);
            Assert.Equal(reserva.MailUsuario, result.MailUsuario);

            _reservaRepositoryMock.Verify(x => x.ObtenerReservasPorId(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task EliminarReservasPorId_RepositoryCalledWithCorrectId()
        {
            // Arrange         
            var reservaId = new ReservaBuilder().Build();

            // Act
            await _reservaService.EliminarReservasPorId(reservaId.Id);

            // Assert
            _reservaRepositoryMock.Verify(repo => repo.EliminarReservasPorId(reservaId.Id), Times.Once);
        }


        [Fact]
        public async Task CrearReserva_DeberiaLlamarAlRepositorioYRetornarReserva()
        {
            // Arrange            
            var reserva = new ReservaBuilder().Build();

            _reservaRepositoryMock
                .Setup(repo => repo.CrearReserva(It.IsAny<Reserva>()))
                .ReturnsAsync(reserva);

            // Act
            var resultado = await _reservaService.CrearReserva(reserva);

            // Assert
            Assert.Equal(reserva, resultado);
            _reservaRepositoryMock.Verify(repo => repo.CrearReserva(It.Is<Reserva>(r => r == reserva)), Times.Once);
        }


        [Fact]
        public async Task ActualizarReserva_DeberiaLlamarAActualizarReservaDelRepositorio()
        {
            // Arrange            

            Guid id = Guid.Parse("00000000-0000-0000-0000-000000000000");

            var actualizarReservaDto = new ActualizarReservaDtoBuilder()
                .WithId(id)
                .WithNumeroAsiento(11)
                .WithFechaSalida(DateTime.Now)
                .Build();

            // Act
            await _reservaService.ActualizarReserva(actualizarReservaDto);

            // Assert
            _reservaRepositoryMock.Verify(repo => repo.ActualizarReserva(It.Is<ActualizarReservaDto>(dto =>
                dto.Id == actualizarReservaDto.Id &&
                dto.NumeroAsiento == actualizarReservaDto.NumeroAsiento &&
                dto.FechaSalida == actualizarReservaDto.FechaSalida
            )), Times.Once);
        }
    }


}

