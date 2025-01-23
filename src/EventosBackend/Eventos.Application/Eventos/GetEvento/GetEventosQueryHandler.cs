using Dapper;
using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;

namespace Eventos.Application.Eventos.GetEvento
{
    internal sealed class GetEventosQueryHandler : IQueryHandler<GetEventosQuery, IReadOnlyList<EventoResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEventosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<EventoResponse>>> Handle(GetEventosQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    idUsuario AS IdUsuario,
                    nombre AS Nombre,
                    descripcion AS Descripcion,
                    capacidadMaxima AS CapacidadMaxima,
                    capacidadActual AS CapacidadActual,
                    fechaEvento AS FechaEvento,
                    fechaCreacion AS FechaCreacion
                FROM eventos
            """;

            var eventos = await connection.QueryAsync<EventoResponse>(
                    sql
                );

            return eventos.ToList();
        }
    }
}
