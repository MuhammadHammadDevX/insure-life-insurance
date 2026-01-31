using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsurance.Migrations
{
    /// <inheritdoc />
    public partial class updateuserpolicyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "policyID",
                table: "tbl_userpolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "policyID",
                table: "tbl_userpolicy");
        }
    }
}
