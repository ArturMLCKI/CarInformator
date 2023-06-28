using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInformator.Data.Migrations
{
    /// <inheritdoc />
    public partial class carReapier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCarInsuranceHistorian_Cars_InsuredCarsCarId",
                table: "CarCarInsuranceHistorian");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InsuredCarsCarId",
                table: "CarCarInsuranceHistorian",
                newName: "InsuredCarsId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCarInsuranceHistorian_InsuredCarsCarId",
                table: "CarCarInsuranceHistorian",
                newName: "IX_CarCarInsuranceHistorian_InsuredCarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCarInsuranceHistorian_Cars_InsuredCarsId",
                table: "CarCarInsuranceHistorian",
                column: "InsuredCarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCarInsuranceHistorian_Cars_InsuredCarsId",
                table: "CarCarInsuranceHistorian");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "InsuredCarsId",
                table: "CarCarInsuranceHistorian",
                newName: "InsuredCarsCarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCarInsuranceHistorian_InsuredCarsId",
                table: "CarCarInsuranceHistorian",
                newName: "IX_CarCarInsuranceHistorian_InsuredCarsCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarCarInsuranceHistorian_Cars_InsuredCarsCarId",
                table: "CarCarInsuranceHistorian",
                column: "InsuredCarsCarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
