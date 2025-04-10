using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalMgtSystem.Migrations
{
    /// <inheritdoc />
    public partial class UtilityAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UtilityType",
                table: "UtilityAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UtilityAccount_UnitID",
                table: "UtilityAccount",
                column: "UnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilityAccount_Unit_UnitID",
                table: "UtilityAccount",
                column: "UnitID",
                principalTable: "Unit",
                principalColumn: "UnitID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilityAccount_Unit_UnitID",
                table: "UtilityAccount");

            migrationBuilder.DropIndex(
                name: "IX_UtilityAccount_UnitID",
                table: "UtilityAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UtilityType",
                table: "UtilityAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
