using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddYearFieldToTaxScopeAndChangeFromDateAndToDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "TaxScopes");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "TaxScopes");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FromTime",
                table: "TaxScopes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ToTime",
                table: "TaxScopes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "TaxScopes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "TaxScopes");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "TaxScopes");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "TaxScopes");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "TaxScopes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "TaxScopes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
