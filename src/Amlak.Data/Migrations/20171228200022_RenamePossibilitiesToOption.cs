using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amlak.Data.Migrations
{
    public partial class RenamePossibilitiesToOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PossibilitiesIdsJson",
                table: "House",
                newName: "OptionIdsJson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptionIdsJson",
                table: "House",
                newName: "PossibilitiesIdsJson");
        }
    }
}
