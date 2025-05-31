using Dapper;
using Eventos.Application.Abstractions.Data;
using Eventos.Application.Abstractions.Messaging;
using Eventos.Domain.Abstractions;
using Eventos.Domain.Entities.Users;

namespace Eventos.Application.Usuarios.GetUsuario
{
    internal sealed class GetUsuarioQueryHandler : IQueryHandler<GetUsuarioQuery, UsuarioResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUsuarioQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<UsuarioResponse>> Handle(
            GetUsuarioQuery request, 
            CancellationToken cancellationToken
        )
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    nombre AS Nombre,
                    apellido AS Apellido,
                    email AS Email,
                    fecha_creacion AS FechaCreacion
                FROM usuarios
            """;

            UsuarioResponse usuario = await connection.QueryFirstOrDefaultAsync<UsuarioResponse>(
                sql,
                new
                {
                    request.UsuarioId,
                }
            );

            return usuario!;
        }
    }
}
