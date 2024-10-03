using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInspectionAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    CarRegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.CarRegistrationNumber);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalTests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarRegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOfInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOperational = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalTests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_TechnicalTests_Vehicles_CarRegistrationNumber",
                        column: x => x.CarRegistrationNumber,
                        principalTable: "Vehicles",
                        principalColumn: "CarRegistrationNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalTests_CarRegistrationNumber",
                table: "TechnicalTests",
                column: "CarRegistrationNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalTests");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
