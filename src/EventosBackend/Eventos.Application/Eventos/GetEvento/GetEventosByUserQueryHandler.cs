using Dapper;
using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;

namespace Eventos.Application.Eventos.GetEvento
{
    internal sealed class GetEventosByUserQueryHandler : IQueryHandler<GetEventosByUserQuery, IReadOnlyList<EventoResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEventosByUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<EventoResponse>>> Handle(GetEventosByUserQuery request, CancellationToken cancellationToken)
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
                FROM eventos WHERE id_usuario = @IdUser
            """;

            IEnumerable<EventoResponse> eventos = await connection.QueryAsync<EventoResponse>(
                    sql,
                    new
                    {
                        request.IdUser
                    }
                );

            return eventos.ToList();
        }
    }
}
