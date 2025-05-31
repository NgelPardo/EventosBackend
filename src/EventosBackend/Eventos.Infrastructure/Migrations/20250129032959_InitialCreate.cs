using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    password_hash = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacidad_maxima = table.Column<int>(type: "int", nullable: true),
                    capacidad_actual = table.Column<int>(type: "int", nullable: true),
                    fecha_evento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eventos", x => x.id);
                    table.ForeignKey(
                        name: "fk_eventos_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inscripciones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    evento_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inscripciones", x => x.id);
                    table.ForeignKey(
                        name: "fk_inscripciones_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_eventos_id_usuario",
                table: "eventos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "ix_inscripciones_usuario_id",
                table: "inscripciones",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos");

            migrationBuilder.DropTable(
                name: "inscripciones");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
