using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsurance.Migrations
{
    /// <inheritdoc />
    public partial class updateclaimsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "claim_requestid",
                table: "tbl_claim",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "claim_requestid",
                table: "tbl_claim");
        }
    }
}
