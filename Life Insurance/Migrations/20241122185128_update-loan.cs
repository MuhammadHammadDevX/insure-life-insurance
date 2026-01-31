using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updateloan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_loan_termplanyearlymonthly_id",
                table: "tbl_loan",
                column: "termplanyearlymonthly_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_loan_user_id",
                table: "tbl_loan",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_loan_tbl_termplanyearlymonthly_termplanyearlymonthly_id",
                table: "tbl_loan",
                column: "termplanyearlymonthly_id",
                principalTable: "tbl_termplanyearlymonthly",
                principalColumn: "termplanyearlymonthly_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_loan_tbl_users_user_id",
                table: "tbl_loan",
                column: "user_id",
                principalTable: "tbl_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_loan_tbl_termplanyearlymonthly_termplanyearlymonthly_id",
                table: "tbl_loan");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_loan_tbl_users_user_id",
                table: "tbl_loan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_loan_termplanyearlymonthly_id",
                table: "tbl_loan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_loan_user_id",
                table: "tbl_loan");
        }
    }
}
