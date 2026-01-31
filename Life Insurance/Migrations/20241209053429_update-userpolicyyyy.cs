using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class updateuserpolicyyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "insurancepolicy_id",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "termplanyearly_id",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tbl_userpolicy");

            migrationBuilder.RenameColumn(
                name: "userpolicy_premiumpaid",
                table: "tbl_userpolicy",
                newName: "userpolicy_termplan");

            migrationBuilder.RenameColumn(
                name: "userpolicy_enddate",
                table: "tbl_userpolicy",
                newName: "userpolicy_sourceofincome");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_city",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_cnicissuancedate",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_cnicnumber",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_dateofbirth",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_emailaddress",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_fatherhusbandname",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_gender",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_insurancepolicyname",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_mobilenumber",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_monthlynetincome",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_name",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_organizationname",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_organizationsector",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userpolicy_residentialaddress",
                table: "tbl_userpolicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userpolicy_city",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_cnicissuancedate",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_cnicnumber",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_dateofbirth",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_emailaddress",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_fatherhusbandname",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_gender",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_insurancepolicyname",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_mobilenumber",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_monthlynetincome",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_name",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_organizationname",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_organizationsector",
                table: "tbl_userpolicy");

            migrationBuilder.DropColumn(
                name: "userpolicy_residentialaddress",
                table: "tbl_userpolicy");

            migrationBuilder.RenameColumn(
                name: "userpolicy_termplan",
                table: "tbl_userpolicy",
                newName: "userpolicy_premiumpaid");

            migrationBuilder.RenameColumn(
                name: "userpolicy_sourceofincome",
                table: "tbl_userpolicy",
                newName: "userpolicy_enddate");

            migrationBuilder.AddColumn<int>(
                name: "insurancepolicy_id",
                table: "tbl_userpolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "termplanyearly_id",
                table: "tbl_userpolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "tbl_userpolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
