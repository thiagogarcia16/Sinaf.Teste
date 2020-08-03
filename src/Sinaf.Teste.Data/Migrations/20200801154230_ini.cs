using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinaf.Teste.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(256)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corretor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(512)", nullable: false),
                    ClienteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(11)", nullable: false),
                    ClienteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apolice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(nullable: false),
                    CorretorId = table.Column<long>(nullable: false),
                    Premio = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apolice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apolice_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apolice_Corretor_CorretorId",
                        column: x => x.CorretorId,
                        principalSchema: "dbo",
                        principalTable: "Corretor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cobertura",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(256)", nullable: false),
                    ImportanciaSegurada = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    ApoliceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobertura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobertura_Apolice_ApoliceId",
                        column: x => x.ApoliceId,
                        principalSchema: "dbo",
                        principalTable: "Apolice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(256)", nullable: false),
                    ApoliceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependente_Apolice_ApoliceId",
                        column: x => x.ApoliceId,
                        principalSchema: "dbo",
                        principalTable: "Apolice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apolice_ClienteId",
                schema: "dbo",
                table: "Apolice",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Apolice_CorretorId",
                schema: "dbo",
                table: "Apolice",
                column: "CorretorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobertura_ApoliceId",
                schema: "dbo",
                table: "Cobertura",
                column: "ApoliceId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_ApoliceId",
                schema: "dbo",
                table: "Dependente",
                column: "ApoliceId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                schema: "dbo",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_ClienteId",
                schema: "dbo",
                table: "Telefone",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobertura",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Dependente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Telefone",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Apolice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Corretor",
                schema: "dbo");
        }
    }
}
