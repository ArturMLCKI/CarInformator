using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInformator.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTableCarInsurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "CarInsurances",
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
                    table.PrimaryKey("PK_CarInsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarInsurance",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CarInsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInsurance", x => new { x.CarId, x.CarInsuranceId });
                    table.ForeignKey(
                        name: "FK_CarInsurance_CarInsurances_CarInsuranceId",
                        column: x => x.CarInsuranceId,
                        principalTable: "CarInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarInsurance_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarInsurance_CarInsuranceId",
                table: "CarInsurance",
                column: "CarInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_User_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_User_UserId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarInsurance");

            migrationBuilder.DropTable(
                name: "CarInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
