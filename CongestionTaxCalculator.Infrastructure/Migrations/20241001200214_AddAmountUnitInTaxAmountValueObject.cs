using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmountUnitInTaxAmountValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxAmount_MyProperty",
                table: "TaxScopes",
                newName: "TaxAmount_Amount");

            migrationBuilder.RenameColumn(
                name: "MinimumAmount_MyProperty",
                table: "TaxRoles",
                newName: "MinimumAmount_Amount");

            migrationBuilder.RenameColumn(
                name: "MaximumAmount_MyProperty",
                table: "TaxRoles",
                newName: "MaximumAmount_Amount");

            migrationBuilder.AddColumn<int>(
                name: "TaxAmount_AmountUnit",
                table: "TaxScopes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaximumAmount_AmountUnit",
                table: "TaxRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumAmount_AmountUnit",
                table: "TaxRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxAmount_AmountUnit",
                table: "TaxScopes");

            migrationBuilder.DropColumn(
                name: "MaximumAmount_AmountUnit",
                table: "TaxRoles");

            migrationBuilder.DropColumn(
                name: "MinimumAmount_AmountUnit",
                table: "TaxRoles");

            migrationBuilder.RenameColumn(
                name: "TaxAmount_Amount",
                table: "TaxScopes",
                newName: "TaxAmount_MyProperty");

            migrationBuilder.RenameColumn(
                name: "MinimumAmount_Amount",
                table: "TaxRoles",
                newName: "MinimumAmount_MyProperty");

            migrationBuilder.RenameColumn(
                name: "MaximumAmount_Amount",
                table: "TaxRoles",
                newName: "MaximumAmount_MyProperty");
        }
    }
}
