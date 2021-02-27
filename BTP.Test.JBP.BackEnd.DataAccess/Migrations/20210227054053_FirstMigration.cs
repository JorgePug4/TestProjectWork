using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTP.Test.JBP.BackEnd.DataAccess.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDAssignments = table.Column<int>(type: "int", nullable: false),
                    IDStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_IDAssignments",
                        column: x => x.IDAssignments,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Student_IDStudent",
                        column: x => x.IDStudent,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Español" },
                    { 2, "Matematicas" },
                    { 3, "Ingles" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "ID", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jorge Bolaños Puga" },
                    { 2, new DateTime(1996, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Antonio Ramirez Henandez" },
                    { 3, new DateTime(1997, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo Gomez Perez" }
                });

            migrationBuilder.InsertData(
                table: "StudentAssignments",
                columns: new[] { "ID", "IDAssignments", "IDStudent" },
                values: new object[,]
                {
                    { 2, 3, 1 },
                    { 6, 2, 1 },
                    { 1, 1, 2 },
                    { 5, 3, 2 },
                    { 3, 2, 3 },
                    { 4, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_IDAssignments",
                table: "StudentAssignments",
                column: "IDAssignments");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_IDStudent",
                table: "StudentAssignments",
                column: "IDStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignments");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
