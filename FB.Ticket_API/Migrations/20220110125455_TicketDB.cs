using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FB.Ticket_API.Migrations
{
    public partial class TicketDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Flight",
            //    columns: table => new
            //    {
            //        FlightNumber = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Flightname = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Intrument_Used = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        From_Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        To_Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        AirLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        TotalBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
            //        TotalNonBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
            //        NoOfRows = table.Column<int>(type: "int", nullable: false),
            //        MealType = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FlightForTicket", x => x.FlightNumber);
            //    });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    PNR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<int>(type: "DateTime", nullable: false),

                    TotalPrice= table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.PNR);
                    table.ForeignKey(
                        name: "FK_Tickets_Flight_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flight",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightID",
                table: "Tickets",
                column: "FlightID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            //migrationBuilder.DropTable(
            //    name: "FlightForTicket");
        }
    }
}
