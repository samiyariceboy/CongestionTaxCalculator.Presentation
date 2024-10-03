using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicensePlates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VehicleOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleOwnerNationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensePlates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TaxOn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaximumAmount_MyProperty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumAmount_MyProperty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxStations_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxRoleRegions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TaxRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRoleRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRoleRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRoleRegions_TaxRoles_TaxRoleId",
                        column: x => x.TaxRoleId,
                        principalTable: "TaxRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TaxRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxAmount_MyProperty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxScopes_TaxRoles_TaxRoleId",
                        column: x => x.TaxRoleId,
                        principalTable: "TaxRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxRoleVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRoleVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRoleVehicles_TaxRoles_TaxRoleId",
                        column: x => x.TaxRoleId,
                        principalTable: "TaxRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRoleVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxReceipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    LicensePlateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxScopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceivedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxReceipts_LicensePlates_LicensePlateId",
                        column: x => x.LicensePlateId,
                        principalTable: "LicensePlates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxReceipts_TaxScopes_TaxScopeId",
                        column: x => x.TaxScopeId,
                        principalTable: "TaxScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxReceipts_TaxStations_TaxStationId",
                        column: x => x.TaxStationId,
                        principalTable: "TaxStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxReceipts_LicensePlateId",
                table: "TaxReceipts",
                column: "LicensePlateId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReceipts_TaxScopeId",
                table: "TaxReceipts",
                column: "TaxScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReceipts_TaxStationId",
                table: "TaxReceipts",
                column: "TaxStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRoleRegions_RegionId",
                table: "TaxRoleRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRoleRegions_TaxRoleId",
                table: "TaxRoleRegions",
                column: "TaxRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRoleVehicles_TaxRoleId",
                table: "TaxRoleVehicles",
                column: "TaxRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRoleVehicles_VehicleId",
                table: "TaxRoleVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxScopes_TaxRoleId",
                table: "TaxScopes",
                column: "TaxRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxStations_RegionId",
                table: "TaxStations",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxReceipts");

            migrationBuilder.DropTable(
                name: "TaxRoleRegions");

            migrationBuilder.DropTable(
                name: "TaxRoleVehicles");

            migrationBuilder.DropTable(
                name: "LicensePlates");

            migrationBuilder.DropTable(
                name: "TaxScopes");

            migrationBuilder.DropTable(
                name: "TaxStations");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "TaxRoles");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
