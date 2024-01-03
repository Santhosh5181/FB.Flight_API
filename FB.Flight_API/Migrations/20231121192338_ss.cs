using Microsoft.EntityFrameworkCore.Migrations;

namespace FB.Flight_API.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Flightname",
                table: "Flight",
                newName: "ScheduledDays");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flight");

            migrationBuilder.RenameColumn(
                name: "ScheduledDays",
                table: "Flight",
                newName: "Flightname");
        }
    }
}
