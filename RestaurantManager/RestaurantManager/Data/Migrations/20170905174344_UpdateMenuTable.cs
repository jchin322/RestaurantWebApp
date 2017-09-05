using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantManager.Data.Migrations
{
    public partial class UpdateMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "MenuItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "MenuLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "Menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "MenuLocation");
        }
    }
}
