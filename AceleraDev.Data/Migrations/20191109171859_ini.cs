using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceleraDev.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 255, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cep = table.Column<string>(maxLength: 255, nullable: true),
                    Rua = table.Column<string>(maxLength: 255, nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 255, nullable: true),
                    Complemento = table.Column<string>(maxLength: 255, nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endereco_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Numero = table.Column<long>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pedido_item",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_item", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_pedido_item_pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_item_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "Cpf", "CriadoEm", "DataNascimento", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { new Guid("df5ab8a7-24ca-4368-99d8-473e12a7b36b"), true, new DateTime(2019, 11, 9, 14, 18, 59, 36, DateTimeKind.Local).AddTicks(675), null, new DateTime(2019, 11, 9, 14, 18, 59, 36, DateTimeKind.Local).AddTicks(675), null, "Thiago", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_endereco_ClienteId",
                table: "endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_ProdutoId",
                table: "pedido_item",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "pedido_item");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
