using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amlak.Data.Migrations
{
    public partial class TowntoHouseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "House",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "House",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecialOffer",
                table: "House",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "House",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "House");

            migrationBuilder.DropColumn(
                name: "City",
                table: "House");

            migrationBuilder.DropColumn(
                name: "IsSpecialOffer",
                table: "House");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "House");
        }
    }
}
