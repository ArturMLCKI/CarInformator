using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInformator.Data.Migrations
{
    /// <inheritdoc />
    public partial class repairCarRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRepairs_Cars_CarId",
                table: "CarRepairs");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRepairs_Cars_CarId",
                table: "CarRepairs",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRepairs_Cars_CarId",
                table: "CarRepairs");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRepairs_Cars_CarId",
                table: "CarRepairs",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
