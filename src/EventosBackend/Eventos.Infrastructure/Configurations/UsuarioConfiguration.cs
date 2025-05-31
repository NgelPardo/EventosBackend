using Eventos.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Configurations
{
    internal sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(usuario => usuario.Id);

            builder.Property(user => user.Nombre)
                .HasMaxLength(200);

            builder.Property(user => user.Apellido)
                .HasMaxLength(200);

            builder.Property(user => user.Email)
                .HasMaxLength(400);

            builder.Property(user => user.PasswordHash)
                .HasMaxLength(2000);

            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
