using Eventos.Domain.Entities.Users;
using FluentAssertions;
using Xunit;

namespace EventosBackend.Domain.UnitTests.Usuarios
{
    public class UsuariosTests
    {
        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            Usuario usuario = Usuario.Create(
                "Miguel",
                "Pardo",
                "correomiguel@correo.com",
                "Test12314%",
                DateTime.Now
                );

            usuario.Nombre.Should().Be("Miguel");
            usuario.Apellido.Should().Be("Pardo");
            usuario.Email.Should().Be("correomiguel@correo.com");
            usuario.PasswordHash.Should().Be("Test12314%");
        }
    }
}
