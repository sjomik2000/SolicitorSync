using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolicitorSync.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaseName = table.Column<string>(type: "TEXT", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    CaseType = table.Column<string>(type: "TEXT", nullable: false),
                    CaseStatus = table.Column<string>(type: "TEXT", nullable: false),
                    AssignedAttorney = table.Column<string>(type: "TEXT", nullable: false),
                    CourtDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CaseDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Documents = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
