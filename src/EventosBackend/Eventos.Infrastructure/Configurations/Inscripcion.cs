using Eventos.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Configurations
{
    internal sealed class Inscripcion : IEntityTypeConfiguration<Domain.Entities.Inscripciones.Inscripcion>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Inscripciones.Inscripcion> builder)
        {
            builder.ToTable("inscripciones");
            builder.HasKey(inscripcion => inscripcion.Id);

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(inscripcion => inscripcion.UsuarioId);
        }
    }
}
