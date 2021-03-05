using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MyThirdMigrationDateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfJourney",
                schema: "dbo",
                table: "tblFlightBook",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FlightDate",
                schema: "dbo",
                table: "tblFlight",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfJourney",
                schema: "dbo",
                table: "tblFlightBook",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "FlightDate",
                schema: "dbo",
                table: "tblFlight",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
