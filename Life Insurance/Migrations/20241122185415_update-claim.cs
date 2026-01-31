using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updateclaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_claim_insurancepolicy_id",
                table: "tbl_claim",
                column: "insurancepolicy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_claim_user_id",
                table: "tbl_claim",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_claim_tbl_insurancepolicy_insurancepolicy_id",
                table: "tbl_claim",
                column: "insurancepolicy_id",
                principalTable: "tbl_insurancepolicy",
                principalColumn: "insurancepolicy_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_claim_tbl_users_user_id",
                table: "tbl_claim",
                column: "user_id",
                principalTable: "tbl_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_claim_tbl_insurancepolicy_insurancepolicy_id",
                table: "tbl_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_claim_tbl_users_user_id",
                table: "tbl_claim");

            migrationBuilder.DropIndex(
                name: "IX_tbl_claim_insurancepolicy_id",
                table: "tbl_claim");

            migrationBuilder.DropIndex(
                name: "IX_tbl_claim_user_id",
                table: "tbl_claim");
        }
    }
}
