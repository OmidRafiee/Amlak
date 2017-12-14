using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amlak.Data.Migrations
{
    public partial class HouseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bathrooms = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    CatrgoryId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Loacation = table.Column<string>(nullable: true),
                    Parkings = table.Column<int>(nullable: false),
                    PhotoGalleryJson = table.Column<string>(nullable: true),
                    PossibilitiesIdsJson = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    Rooms = table.Column<int>(nullable: false),
                    Scale = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                    table.ForeignKey(
                        name: "FK_House_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_House_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_CategoryId",
                table: "House",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_House_UserId",
                table: "House",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
