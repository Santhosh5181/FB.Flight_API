using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FB.Flight_API.Migrations
{
    public partial class FlightDBContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flightname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intrument_Used = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From_Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To_Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    TotalNonBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    NoOfRows = table.Column<int>(type: "int", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),

                    ScheduledDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
