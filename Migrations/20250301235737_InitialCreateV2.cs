using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolicitorSync.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    case_name = table.Column<string>(type: "TEXT", nullable: true),
                    client_name = table.Column<string>(type: "TEXT", nullable: true),
                    case_type = table.Column<string>(type: "TEXT", nullable: true),
                    case_state = table.Column<string>(type: "TEXT", nullable: true),
                    assigned_attorney = table.Column<string>(type: "TEXT", nullable: true),
                    court_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    case_description = table.Column<string>(type: "TEXT", nullable: true),
                    documents = table.Column<string>(type: "TEXT", nullable: true),
                    notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.id);
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
