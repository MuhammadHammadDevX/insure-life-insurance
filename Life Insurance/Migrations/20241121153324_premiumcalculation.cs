using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class premiumcalculation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_premiumcalculation",
                columns: table => new
                {
                    premiumcalculation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    premiumcalculation_calculatedpremium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    premiumcalculation_calculationdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    insurancepolicy_id = table.Column<int>(type: "int", nullable: false),
                    termplanyearlymonthly_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_premiumcalculation", x => x.premiumcalculation_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_premiumcalculation");
        }
    }
}
