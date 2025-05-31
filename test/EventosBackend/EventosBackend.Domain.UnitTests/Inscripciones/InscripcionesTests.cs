using Eventos.Domain.Entities.Inscripciones;
using FluentAssertions;
using Xunit;

namespace EventosBackend.Domain.UnitTests.Inscripciones
{
    public class InscripcionesTests
    {
        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            Guid usuarioId = Guid.NewGuid();
            Guid eventoId = Guid.NewGuid();
            DateTime fechaCreacion = DateTime.Now;

            Inscripcion inscripcion = Inscripcion.Inscribir(
                usuarioId,
                eventoId,
                fechaCreacion
                );

            inscripcion.UsuarioId.Should().Be(usuarioId);
            inscripcion.EventoId.Should().Be(eventoId);
            inscripcion.FechaCreacion.Should().Be(fechaCreacion);
        }
    }
}
