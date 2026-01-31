using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updateclaimsssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "insurancepolicy_id",
                table: "tbl_claim");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tbl_claim");

            migrationBuilder.AddColumn<string>(
                name: "claim_useremail",
                table: "tbl_claim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "claim_username",
                table: "tbl_claim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "claim_userphone",
                table: "tbl_claim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "claim_userpolicynumber",
                table: "tbl_claim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "claim_useremail",
                table: "tbl_claim");

            migrationBuilder.DropColumn(
                name: "claim_username",
                table: "tbl_claim");

            migrationBuilder.DropColumn(
                name: "claim_userphone",
                table: "tbl_claim");

            migrationBuilder.DropColumn(
                name: "claim_userpolicynumber",
                table: "tbl_claim");

            migrationBuilder.AddColumn<int>(
                name: "insurancepolicy_id",
                table: "tbl_claim",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "tbl_claim",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
