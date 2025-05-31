using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Email;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Ports;
using Eventos.Infrastructure.Data;
using Eventos.Infrastructure.Email;
using Eventos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration 
            )
        {
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database")
                ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUsuarioRepository, UserRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IInscripcionRepository, InscripcionRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>( _ => new SqlConnectionFactory(connectionString)); 

            return services;
        }
    }
}
