using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsurance.Migrations
{
    /// <inheritdoc />
    public partial class emi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_emi",
                columns: table => new
                {
                    emi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rate_of_interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tenure = table.Column<int>(type: "int", nullable: false),
                    calculated_emi = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_emi", x => x.emi_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_emi");
        }
    }
}
