using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarGallery.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Fundacao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DescricaoLonga = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Fabricacao = table.Column<DateOnly>(type: "date", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FabricanteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_FabricanteId",
                table: "Carros",
                column: "FabricanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Fabricantes");
        }
    }
}
