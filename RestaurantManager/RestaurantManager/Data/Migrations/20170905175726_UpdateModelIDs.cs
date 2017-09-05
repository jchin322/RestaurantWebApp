using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantManager.Data.Migrations
{
    public partial class UpdateModelIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemID",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "MenuItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "MenuItemID",
                table: "MenuItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "MenuLocation");
        }
    }
}
