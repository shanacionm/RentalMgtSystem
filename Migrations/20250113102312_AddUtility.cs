using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalMgtSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddUtility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utility",
                columns: table => new
                {
                    UtilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MainMeterReading = table.Column<double>(type: "float", nullable: true),
                    SubmeterReading = table.Column<double>(type: "float", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utility", x => x.UtilityID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utility");
        }
    }
}
