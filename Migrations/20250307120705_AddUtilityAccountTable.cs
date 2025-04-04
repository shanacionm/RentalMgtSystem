using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalMgtSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUtilityAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilityAccount",
                columns: table => new
                {
                    UtilityAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilityAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: true),
                    UtilityType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityAccount", x => x.UtilityAccountID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilityAccount");
        }
    }
}
