using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalMgtSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUtility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BillingAmount",
                table: "Utility",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAmount",
                table: "Utility");
        }
    }
}
