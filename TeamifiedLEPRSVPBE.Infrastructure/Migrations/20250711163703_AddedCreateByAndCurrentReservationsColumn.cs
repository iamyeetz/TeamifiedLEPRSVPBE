using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamifiedLEPRSVPBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreateByAndCurrentReservationsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentReservations",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CurrentReservations",
                table: "Events");
        }
    }
}
