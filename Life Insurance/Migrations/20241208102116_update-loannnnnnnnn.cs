using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updateloannnnnnnnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "termplanyearlymonthly_id",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tbl_loan");

            migrationBuilder.RenameColumn(
                name: "loan_repaymentamount",
                table: "tbl_loan",
                newName: "loan_usersector");

            migrationBuilder.RenameColumn(
                name: "loan_date",
                table: "tbl_loan",
                newName: "loan_userphonenumber");

            migrationBuilder.RenameColumn(
                name: "loan_amount",
                table: "tbl_loan",
                newName: "loan_userorganizationname");

            migrationBuilder.AddColumn<string>(
                name: "loan_desiredloanrepaymentperiod",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_usercity",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_usercnicnumber",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_userdateofbirth",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_useremail",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_userloanamount",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_usermontlynetincome",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loan_username",
                table: "tbl_loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "loan_desiredloanrepaymentperiod",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_usercity",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_usercnicnumber",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_userdateofbirth",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_useremail",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_userloanamount",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_usermontlynetincome",
                table: "tbl_loan");

            migrationBuilder.DropColumn(
                name: "loan_username",
                table: "tbl_loan");

            migrationBuilder.RenameColumn(
                name: "loan_usersector",
                table: "tbl_loan",
                newName: "loan_repaymentamount");

            migrationBuilder.RenameColumn(
                name: "loan_userphonenumber",
                table: "tbl_loan",
                newName: "loan_date");

            migrationBuilder.RenameColumn(
                name: "loan_userorganizationname",
                table: "tbl_loan",
                newName: "loan_amount");

            migrationBuilder.AddColumn<int>(
                name: "termplanyearlymonthly_id",
                table: "tbl_loan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "tbl_loan",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
