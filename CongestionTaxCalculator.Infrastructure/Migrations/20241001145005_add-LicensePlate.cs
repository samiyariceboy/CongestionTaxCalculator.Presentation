using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLicensePlate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LicensePlates_VehicleId",
                table: "LicensePlates",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicensePlates_Vehicles_VehicleId",
                table: "LicensePlates",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicensePlates_Vehicles_VehicleId",
                table: "LicensePlates");

            migrationBuilder.DropIndex(
                name: "IX_LicensePlates_VehicleId",
                table: "LicensePlates");
        }
    }
}
