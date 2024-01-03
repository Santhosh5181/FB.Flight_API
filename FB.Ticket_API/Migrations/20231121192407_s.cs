using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FB.Ticket_API.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_FlightForTicket_FlightID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FlightID",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightForTicket",
                table: "FlightForTicket");

            migrationBuilder.RenameTable(
                name: "FlightForTicket",
                newName: "Flight");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Tickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ScheduledDays",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "FlightNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ScheduledDays",
                table: "Flight");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "FlightForTicket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightForTicket",
                table: "FlightForTicket",
                column: "FlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightID",
                table: "Tickets",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_FlightForTicket_FlightID",
                table: "Tickets",
                column: "FlightID",
                principalTable: "FlightForTicket",
                principalColumn: "FlightNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
