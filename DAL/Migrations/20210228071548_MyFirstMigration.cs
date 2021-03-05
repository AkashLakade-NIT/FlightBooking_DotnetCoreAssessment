using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tblFlight",
                schema: "dbo",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceLocation = table.Column<string>(type: "varchar(500)", nullable: false),
                    DestinationLocation = table.Column<string>(type: "varchar(500)", nullable: false),
                    FlightAmount = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    AvailableTickets = table.Column<string>(type: "varchar(500)", nullable: false),
                    FlightDate = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFlight", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "tblFlightBook",
                schema: "dbo",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(500)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(500)", nullable: false),
                    Age = table.Column<string>(type: "varchar(100)", nullable: false),
                    DateOfJourney = table.Column<string>(type: "varchar(500)", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFlightBook", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_tblFlightBook_tblFlight_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "dbo",
                        principalTable: "tblFlight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFlightBook_FlightId",
                schema: "dbo",
                table: "tblFlightBook",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFlightBook",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tblFlight",
                schema: "dbo");
        }
    }
}
