using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingPlatform.Infrastructure.Migrations
{
    public partial class UpdatedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerNight",
                table: "Rooms",
                newName: "PricePerNightPhp");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Bookings",
                newName: "UtcDateTo");

            migrationBuilder.RenameColumn(
                name: "DateFrom",
                table: "Bookings",
                newName: "UtcDateFrom");

            migrationBuilder.RenameColumn(
                name: "BookedDate",
                table: "Bookings",
                newName: "UtcBookedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerNightPhp",
                table: "Rooms",
                newName: "PricePerNight");

            migrationBuilder.RenameColumn(
                name: "UtcDateTo",
                table: "Bookings",
                newName: "DateTo");

            migrationBuilder.RenameColumn(
                name: "UtcDateFrom",
                table: "Bookings",
                newName: "DateFrom");

            migrationBuilder.RenameColumn(
                name: "UtcBookedDate",
                table: "Bookings",
                newName: "BookedDate");
        }
    }
}
