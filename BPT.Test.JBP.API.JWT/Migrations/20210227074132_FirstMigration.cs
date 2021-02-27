using Microsoft.EntityFrameworkCore.Migrations;

namespace BPT.Test.JBP.API.JWT.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginJWT",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginJWT", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "LoginJWT",
                columns: new[] { "Username", "Password" },
                values: new object[] { "Jorge", "PASSWORDJWT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginJWT");
        }
    }
}
