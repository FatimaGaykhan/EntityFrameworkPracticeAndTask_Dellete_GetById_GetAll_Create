﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkConsole.Migrations
{
    public partial class AddNameColumIntoSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Settings");
        }
    }
}
