using Dapper;
using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using MediatR;

namespace Eventos.Application.Inscripciones.GetInscripcion
{
    internal sealed class GetInscripcionesByUserQueryHandler : IQueryHandler<GetInscripcionesByUserQuery, IReadOnlyList<InscripcionesUsuarioResponse>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public GetInscripcionesByUserQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<IReadOnlyList<InscripcionesUsuarioResponse>>> Handle(GetInscripcionesByUserQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
            	    ins.id AS Id,
            	    ins.usuario_id AS UsuarioId,
            	    ins.evento_id AS EventoId,
            	    ins.fecha_creacion AS FechaCreacion,
            	    evt.nombre AS Nombre,
            	    evt.descripcion AS Descripcion,
            	    evt.ubicacion AS Ubicacion,
            	    evt.fecha_evento AS FechaEvento
                FROM inscripciones ins
                INNER JOIN eventos evt ON evt.id = ins.evento_id
                WHERE ins.usuario_id = @UserId
            """;

            IEnumerable<InscripcionesUsuarioResponse> inscripcionesUsuario = await connection.QueryAsync<InscripcionesUsuarioResponse>(
                sql,
                new
                {
                    request.UserId
                }
            );

            return inscripcionesUsuario.ToList();
        }
    }
}
