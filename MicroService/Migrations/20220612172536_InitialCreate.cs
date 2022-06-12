using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "datas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    x = table.Column<float>(type: "REAL", nullable: false),
                    y = table.Column<float>(type: "REAL", nullable: false),
                    type1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    type2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    type3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    type4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    type5 = table.Column<bool>(type: "INTEGER", nullable: false),
                    type6 = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datas");
        }
    }
}
