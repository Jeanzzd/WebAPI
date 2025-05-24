using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Net.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Usuarios_UsuarioId",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_UsuarioId",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Motos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Motos_UsuarioId",
                table: "Motos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Usuarios_UsuarioId",
                table: "Motos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
