using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanFlow_transport_management.Migrations
{
    /// <inheritdoc />
    public partial class migVehicleStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vehicules");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastMaintenance",
                table: "Vehicules",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Statut",
                table: "Vehicules",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMaintenance",
                table: "Vehicules");

            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Vehicules");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Vehicules",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
