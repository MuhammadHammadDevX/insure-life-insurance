using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class insurancepolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_insurancepolicy",
                columns: table => new
                {
                    insurancepolicy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    insurancepolicy_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insurancepolicy_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insurancepolicy_premiumamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insurancepolicy_covergeamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    policytype_id = table.Column<int>(type: "int", nullable: false),
                    termplanyearly_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_insurancepolicy", x => x.insurancepolicy_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_insurancepolicy");
        }
    }
}
