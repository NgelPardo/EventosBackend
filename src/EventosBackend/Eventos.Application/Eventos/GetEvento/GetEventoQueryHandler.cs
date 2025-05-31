using Dapper;
using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;

namespace Eventos.Application.Eventos.GetEvento
{
    internal sealed class GetEventoQueryHandler : IQueryHandler<GetEventoQuery, EventoResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetEventoQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<EventoResponse>> Handle(
            GetEventoQuery request, 
            CancellationToken cancellationToken
            )
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    id_usuario AS IdUsuario,
                    nombre AS Nombre,
                    descripcion AS Descripcion,
                    ubicacion AS Ubicacion,
                    capacidad_maxima AS CapacidadMaxima,
                    capacidad_actual AS CapacidadActual,
                    fecha_evento AS FechaEvento,
                    fecha_creacion AS FechaCreacion
                FROM eventos WHERE id = @EventoId
            """;

            EventoResponse evento = await connection.QueryFirstOrDefaultAsync<EventoResponse>(
                sql,
                new
                {
                    request.EventoId
                }
            );

            return evento!;
        }
    }
}
