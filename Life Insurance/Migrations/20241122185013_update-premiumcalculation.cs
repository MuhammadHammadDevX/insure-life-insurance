using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updatepremiumcalculation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_premiumcalculation_insurancepolicy_id",
                table: "tbl_premiumcalculation",
                column: "insurancepolicy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_premiumcalculation_termplanyearlymonthly_id",
                table: "tbl_premiumcalculation",
                column: "termplanyearlymonthly_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_premiumcalculation_user_id",
                table: "tbl_premiumcalculation",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_premiumcalculation_tbl_insurancepolicy_insurancepolicy_id",
                table: "tbl_premiumcalculation",
                column: "insurancepolicy_id",
                principalTable: "tbl_insurancepolicy",
                principalColumn: "insurancepolicy_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_premiumcalculation_tbl_termplanyearlymonthly_termplanyearlymonthly_id",
                table: "tbl_premiumcalculation",
                column: "termplanyearlymonthly_id",
                principalTable: "tbl_termplanyearlymonthly",
                principalColumn: "termplanyearlymonthly_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_premiumcalculation_tbl_users_user_id",
                table: "tbl_premiumcalculation",
                column: "user_id",
                principalTable: "tbl_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_premiumcalculation_tbl_insurancepolicy_insurancepolicy_id",
                table: "tbl_premiumcalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_premiumcalculation_tbl_termplanyearlymonthly_termplanyearlymonthly_id",
                table: "tbl_premiumcalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_premiumcalculation_tbl_users_user_id",
                table: "tbl_premiumcalculation");

            migrationBuilder.DropIndex(
                name: "IX_tbl_premiumcalculation_insurancepolicy_id",
                table: "tbl_premiumcalculation");

            migrationBuilder.DropIndex(
                name: "IX_tbl_premiumcalculation_termplanyearlymonthly_id",
                table: "tbl_premiumcalculation");

            migrationBuilder.DropIndex(
                name: "IX_tbl_premiumcalculation_user_id",
                table: "tbl_premiumcalculation");
        }
    }
}
