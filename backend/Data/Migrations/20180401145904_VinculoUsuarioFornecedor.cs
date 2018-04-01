using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class VinculoUsuarioFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdUsuario",
                table: "Fornecedor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_IdUsuario",
                table: "Fornecedor",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Usuario_IdUsuario",
                table: "Fornecedor",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Usuario_IdUsuario",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_IdUsuario",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Fornecedor");
        }
    }
}
