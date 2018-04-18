using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace infomercsite.Migrations
{
    public partial class usuarioAtivoePremium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "INFOMERC_USUARIO",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Premium",
                table: "INFOMERC_USUARIO",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "INFOMERC_USUARIO");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "INFOMERC_USUARIO");
        }
    }
}
