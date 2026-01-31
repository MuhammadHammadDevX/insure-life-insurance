using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsurance.Migrations
{
    /// <inheritdoc />
    public partial class addnayacolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "calculated_premium",
                table: "tbl_pre",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calculated_premium",
                table: "tbl_pre");
        }
    }
}
