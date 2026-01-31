using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Life_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class userpolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_userpolicy",
                columns: table => new
                {
                    userpolicy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userpolicy_startdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userpolicy_enddate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userpolicy_premiumpaid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    insurancepolicy_id = table.Column<int>(type: "int", nullable: false),
                    termplanyearly_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_userpolicy", x => x.userpolicy_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_userpolicy");
        }
    }
}
