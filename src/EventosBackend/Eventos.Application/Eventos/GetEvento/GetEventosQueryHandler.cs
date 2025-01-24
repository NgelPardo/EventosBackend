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
                SELECT e.id AS Id,
                   e.nombre AS Nombre,
                   e.descripcion AS Descripcion,
                   e.ubicacion AS Ubicacion,
                   e.capacidad_maxima AS CapacidadMaxima,
                   e.capacidad_actual AS CapacidadActual,
                   e.fecha_evento AS FechaEvento
                FROM eventos e
                WHERE e.id NOT IN (
                    SELECT i.evento_id
                    FROM inscripciones i
                    WHERE i.usuario_id = @UserId  
                );
            """;

            var eventos = await connection.QueryAsync<EventoResponse>(
                    sql,
                    new
                    {
                        request.UserId
                    }
                );

            return eventos.ToList();
        }
    }
}
