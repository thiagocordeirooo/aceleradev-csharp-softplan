using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceleraDev.Data.Migrations
{
    public partial class ini2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_endereco_cliente_ClienteId",
                table: "endereco");

            migrationBuilder.DeleteData(
                table: "cliente",
                keyColumn: "Id",
                keyValue: new Guid("68c41759-a206-4e37-83ec-3a8b76aaa8f5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "endereco",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "Cpf", "CriadoEm", "DataNascimento", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { new Guid("821d64a7-66bc-44d0-9273-d733d1dfb7e4"), true, new DateTime(2019, 11, 16, 10, 44, 45, 465, DateTimeKind.Local).AddTicks(5866), null, new DateTime(2019, 11, 16, 10, 44, 45, 465, DateTimeKind.Local).AddTicks(5866), null, "Thiago", null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_endereco_cliente_ClienteId",
                table: "endereco",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_endereco_cliente_ClienteId",
                table: "endereco");

            migrationBuilder.DeleteData(
                table: "cliente",
                keyColumn: "Id",
                keyValue: new Guid("821d64a7-66bc-44d0-9273-d733d1dfb7e4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "endereco",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "Cpf", "CriadoEm", "DataNascimento", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { new Guid("68c41759-a206-4e37-83ec-3a8b76aaa8f5"), true, new DateTime(2019, 11, 16, 9, 43, 13, 338, DateTimeKind.Local).AddTicks(6231), null, new DateTime(2019, 11, 16, 9, 43, 13, 338, DateTimeKind.Local).AddTicks(6231), null, "Thiago", null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_endereco_cliente_ClienteId",
                table: "endereco",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
