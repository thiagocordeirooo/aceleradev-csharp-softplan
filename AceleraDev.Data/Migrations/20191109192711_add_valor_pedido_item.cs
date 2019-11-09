using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceleraDev.Data.Migrations
{
    public partial class add_valor_pedido_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cliente",
                keyColumn: "Id",
                keyValue: new Guid("df5ab8a7-24ca-4368-99d8-473e12a7b36b"));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorUnitario",
                table: "pedido_item",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "Cpf", "CriadoEm", "DataNascimento", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { new Guid("b5819144-e118-4e03-8424-495a1283ecea"), true, new DateTime(2019, 11, 9, 16, 27, 11, 363, DateTimeKind.Local).AddTicks(7797), null, new DateTime(2019, 11, 9, 16, 27, 11, 363, DateTimeKind.Local).AddTicks(7797), null, "Thiago", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cliente",
                keyColumn: "Id",
                keyValue: new Guid("b5819144-e118-4e03-8424-495a1283ecea"));

            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "pedido_item");

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "Cpf", "CriadoEm", "DataNascimento", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { new Guid("df5ab8a7-24ca-4368-99d8-473e12a7b36b"), true, new DateTime(2019, 11, 9, 14, 18, 59, 36, DateTimeKind.Local).AddTicks(675), null, new DateTime(2019, 11, 9, 14, 18, 59, 36, DateTimeKind.Local).AddTicks(675), null, "Thiago", null, null });
        }
    }
}
