using Eventos.Domain.Entities.Eventos;
using Eventos.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Configurations
{
    internal sealed class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("eventos");
            builder.HasKey(evento =>  evento.Id);

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(evento => evento.IdUsuario); 

        }
    }
}
