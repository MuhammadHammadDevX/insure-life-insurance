using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class paymenttransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_paymenttransaction",
                columns: table => new
                {
                    paymenttransaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymenttransaction_amountpaid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymenttransaction_paymentdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    insurancepolicy_id = table.Column<int>(type: "int", nullable: false),
                    transactiontype_id = table.Column<int>(type: "int", nullable: false),
                    termplanyearlymonthly_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_paymenttransaction", x => x.paymenttransaction_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_paymenttransaction");
        }
    }
}
