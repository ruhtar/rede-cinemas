using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class Tabeladefuncionariosfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cinemas_Id",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CinemaId",
                table: "Funcionarios",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cinemas_CinemaId",
                table: "Funcionarios",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cinemas_CinemaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_CinemaId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cinemas_Id",
                table: "Funcionarios",
                column: "Id",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
