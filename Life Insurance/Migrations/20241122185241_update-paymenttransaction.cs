using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updatepaymenttransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_paymenttransaction_insurancepolicy_id",
                table: "tbl_paymenttransaction",
                column: "insurancepolicy_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_paymenttransaction_termplanyearlymonthly_id",
                table: "tbl_paymenttransaction",
                column: "termplanyearlymonthly_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_paymenttransaction_transactiontype_id",
                table: "tbl_paymenttransaction",
                column: "transactiontype_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_paymenttransaction_user_id",
                table: "tbl_paymenttransaction",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_insurancepolicy_insurancepolicy_id",
                table: "tbl_paymenttransaction",
                column: "insurancepolicy_id",
                principalTable: "tbl_insurancepolicy",
                principalColumn: "insurancepolicy_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_termplanyearlymonthly_termplanyearlymonthly_id",
                table: "tbl_paymenttransaction",
                column: "termplanyearlymonthly_id",
                principalTable: "tbl_termplanyearlymonthly",
                principalColumn: "termplanyearlymonthly_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_transactiontype_transactiontype_id",
                table: "tbl_paymenttransaction",
                column: "transactiontype_id",
                principalTable: "tbl_transactiontype",
                principalColumn: "transactiontype_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_users_user_id",
                table: "tbl_paymenttransaction",
                column: "user_id",
                principalTable: "tbl_users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_insurancepolicy_insurancepolicy_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_termplanyearlymonthly_termplanyearlymonthly_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_transactiontype_transactiontype_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_paymenttransaction_tbl_users_user_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropIndex(
                name: "IX_tbl_paymenttransaction_insurancepolicy_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropIndex(
                name: "IX_tbl_paymenttransaction_termplanyearlymonthly_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropIndex(
                name: "IX_tbl_paymenttransaction_transactiontype_id",
                table: "tbl_paymenttransaction");

            migrationBuilder.DropIndex(
                name: "IX_tbl_paymenttransaction_user_id",
                table: "tbl_paymenttransaction");
        }
    }
}
