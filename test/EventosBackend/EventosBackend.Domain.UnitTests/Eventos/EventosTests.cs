using Eventos.Domain.Entities.Eventos;
using FluentAssertions;
using Xunit;

namespace EventosBackend.Domain.UnitTests.Eventos
{
    public class EventosTests
    {

        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            Evento evento = Evento.Create(
                Guid.NewGuid(), 
                "Concierto", 
                "Concierto beneficiencia", 
                "Cra78 #24 - 2", 
                1000, 
                new DateTime(2025, 2, 23, 14, 0, 0), 
                DateTime.Now
                );

            evento.Nombre.Should().Be("Concierto");
            evento.Descripcion.Should().Be("Concierto beneficiencia");
            evento.Ubicacion.Should().Be("Cra78 #24 - 2");
            evento.CapacidadMaxima.Should().Be(1000);
            evento.FechaEvento.Should().Be(new DateTime(2025, 2, 23, 14, 0, 0));

        }
    }
}
