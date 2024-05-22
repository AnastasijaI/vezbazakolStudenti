using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studenti.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabVezba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabVezba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Indeks = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ImePrezime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Potpis = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LabVezbaId = table.Column<int>(type: "int", nullable: false),
                    Zavrsena = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Poeni = table.Column<int>(type: "int", nullable: true),
                    DataZavrsuvanje = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLab_LabVezba_LabVezbaId",
                        column: x => x.LabVezbaId,
                        principalTable: "LabVezba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLab_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLab_LabVezbaId",
                table: "StudentLab",
                column: "LabVezbaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLab_StudentId",
                table: "StudentLab",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLab");

            migrationBuilder.DropTable(
                name: "LabVezba");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
