using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perplex.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Onderwerp = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suggestions");
        }
    }
}
