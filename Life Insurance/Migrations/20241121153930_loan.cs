using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class loan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_loan",
                columns: table => new
                {
                    loan_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loan_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loan_amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loan_repaymentamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    termplanyearlymonthly_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_loan", x => x.loan_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_loan");
        }
    }
}
