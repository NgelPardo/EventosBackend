using Dapper;
using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;

namespace Eventos.Application.Inscripciones.GetInscripcion
{
    internal sealed class GetInscripcionQueryHandler : IQueryHandler<GetInscripcionQuery, InscripcionResponse>
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public GetInscripcionQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<InscripcionResponse>> Handle(GetInscripcionQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = """
                SELECT
                    id AS Id,
                    usuario_id AS UsuarioId,
                    evento_id AS EventoId,
                    fecha_creacion AS FechaCreacion
                FROM inscripciones WHERE id = @InscripcionId 
            """;

            var inscripcion = await connection.QueryFirstOrDefaultAsync<InscripcionResponse>(
                sql,
                new
                {
                    request.InscripcionId
                }    
            );

            return inscripcion;
        }
    }
}
