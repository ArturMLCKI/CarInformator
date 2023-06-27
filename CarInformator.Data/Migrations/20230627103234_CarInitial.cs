using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInformator.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentFree = table.Column<bool>(type: "bit", nullable: false),
                    DescAccident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevOwner = table.Column<int>(type: "int", nullable: false),
                    Milage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingExp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Generation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CarCarInsuranceHistorian",
                columns: table => new
                {
                    InsuranceHistoriansId = table.Column<int>(type: "int", nullable: false),
                    InsuredCarsCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCarInsuranceHistorian", x => new { x.InsuranceHistoriansId, x.InsuredCarsCarId });
                    table.ForeignKey(
                        name: "FK_CarCarInsuranceHistorian_Car Insurances_InsuranceHistoriansId",
                        column: x => x.InsuranceHistoriansId,
                        principalTable: "Car Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCarInsuranceHistorian_Cars_InsuredCarsCarId",
                        column: x => x.InsuredCarsCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRepairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepiarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepiarDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRepairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRepairs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCarInsuranceHistorian_InsuredCarsCarId",
                table: "CarCarInsuranceHistorian",
                column: "InsuredCarsCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRepairs_CarId",
                table: "CarRepairs",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCarInsuranceHistorian");

            migrationBuilder.DropTable(
                name: "CarRepairs");

            migrationBuilder.DropTable(
                name: "Car Insurances");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
