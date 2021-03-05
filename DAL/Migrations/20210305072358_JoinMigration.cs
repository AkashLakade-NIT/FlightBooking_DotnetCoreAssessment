using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class JoinMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tblFlightBook",
                schema: "dbo",
                newName: "tblFlightBook");

            migrationBuilder.RenameTable(
                name: "tblFlight",
                schema: "dbo",
                newName: "tblFlight");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "tblFlightBook",
                newName: "tblFlightBook",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "tblFlight",
                newName: "tblFlight",
                newSchema: "dbo");
        }
    }
}
