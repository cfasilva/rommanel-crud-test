using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rommanel.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsentoIE = table.Column<bool>(type: "bit", nullable: false),
                    Endereco_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
