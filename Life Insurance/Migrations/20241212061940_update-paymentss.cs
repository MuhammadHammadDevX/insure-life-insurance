using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsurance.Migrations
{
    /// <inheritdoc />
    public partial class updatepaymentss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "tbl_payment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "tbl_payment");
        }
    }
}
