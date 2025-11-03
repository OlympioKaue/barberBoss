using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barberBoss.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_Novo_Dado_A_Tabela_Billings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Billings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Billings");
        }
    }
}
