using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionNombresTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eventos_usuarios_IdUsuario",
                table: "eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_inscripciones_usuarios_UsuarioId",
                table: "inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_Email",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inscripciones",
                table: "inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_eventos",
                table: "eventos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "usuarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "usuarios",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "usuarios",
                newName: "fecha_creacion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "inscripciones",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "inscripciones",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "inscripciones",
                newName: "fecha_creacion");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "inscripciones",
                newName: "evento_id");

            migrationBuilder.RenameIndex(
                name: "IX_inscripciones_UsuarioId",
                table: "inscripciones",
                newName: "ix_inscripciones_usuario_id");

            migrationBuilder.RenameColumn(
                name: "Ubicacion",
                table: "eventos",
                newName: "ubicacion");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "eventos",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "eventos",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "eventos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "eventos",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "FechaEvento",
                table: "eventos",
                newName: "fecha_evento");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "eventos",
                newName: "fecha_creacion");

            migrationBuilder.RenameColumn(
                name: "CapacidadMaxima",
                table: "eventos",
                newName: "capacidad_maxima");

            migrationBuilder.RenameColumn(
                name: "CapacidadActual",
                table: "eventos",
                newName: "capacidad_actual");

            migrationBuilder.RenameIndex(
                name: "IX_eventos_IdUsuario",
                table: "eventos",
                newName: "ix_eventos_id_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "pk_usuarios",
                table: "usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_inscripciones",
                table: "inscripciones",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_eventos",
                table: "eventos",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_eventos_usuario_id_usuario",
                table: "eventos",
                column: "id_usuario",
                principalTable: "usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_inscripciones_usuario_usuario_id",
                table: "inscripciones",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_eventos_usuario_id_usuario",
                table: "eventos");

            migrationBuilder.DropForeignKey(
                name: "fk_inscripciones_usuario_usuario_id",
                table: "inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "pk_usuarios",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "ix_usuarios_email",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "pk_inscripciones",
                table: "inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "pk_eventos",
                table: "eventos");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "usuarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "fecha_creacion",
                table: "usuarios",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "inscripciones",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "inscripciones",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "fecha_creacion",
                table: "inscripciones",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "evento_id",
                table: "inscripciones",
                newName: "EventoId");

            migrationBuilder.RenameIndex(
                name: "ix_inscripciones_usuario_id",
                table: "inscripciones",
                newName: "IX_inscripciones_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ubicacion",
                table: "eventos",
                newName: "Ubicacion");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "eventos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "eventos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "eventos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "eventos",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "fecha_evento",
                table: "eventos",
                newName: "FechaEvento");

            migrationBuilder.RenameColumn(
                name: "fecha_creacion",
                table: "eventos",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "capacidad_maxima",
                table: "eventos",
                newName: "CapacidadMaxima");

            migrationBuilder.RenameColumn(
                name: "capacidad_actual",
                table: "eventos",
                newName: "CapacidadActual");

            migrationBuilder.RenameIndex(
                name: "ix_eventos_id_usuario",
                table: "eventos",
                newName: "IX_eventos_IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inscripciones",
                table: "inscripciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventos",
                table: "eventos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Email",
                table: "usuarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_eventos_usuarios_IdUsuario",
                table: "eventos",
                column: "IdUsuario",
                principalTable: "usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inscripciones_usuarios_UsuarioId",
                table: "inscripciones",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id");
        }
    }
}
