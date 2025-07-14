using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamifiedLEPRSVPBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedReservationListForUsernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reservations",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reservations",
                table: "Events");
        }
    }
}
