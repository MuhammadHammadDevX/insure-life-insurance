using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updateinsurancepolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_insurancepolicy_policytype_id",
                table: "tbl_insurancepolicy",
                column: "policytype_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_insurancepolicy_termplanyearly_id",
                table: "tbl_insurancepolicy",
                column: "termplanyearly_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_insurancepolicy_tbl_policytype_policytype_id",
                table: "tbl_insurancepolicy",
                column: "policytype_id",
                principalTable: "tbl_policytype",
                principalColumn: "policytype_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_insurancepolicy_tbl_termplanyearly_termplanyearly_id",
                table: "tbl_insurancepolicy",
                column: "termplanyearly_id",
                principalTable: "tbl_termplanyearly",
                principalColumn: "termplanyearly_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_insurancepolicy_tbl_policytype_policytype_id",
                table: "tbl_insurancepolicy");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_insurancepolicy_tbl_termplanyearly_termplanyearly_id",
                table: "tbl_insurancepolicy");

            migrationBuilder.DropIndex(
                name: "IX_tbl_insurancepolicy_policytype_id",
                table: "tbl_insurancepolicy");

            migrationBuilder.DropIndex(
                name: "IX_tbl_insurancepolicy_termplanyearly_id",
                table: "tbl_insurancepolicy");
        }
    }
}
