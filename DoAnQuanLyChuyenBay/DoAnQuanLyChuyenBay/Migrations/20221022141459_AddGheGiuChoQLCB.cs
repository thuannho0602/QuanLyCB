using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCB.API.Migrations
{
    public partial class AddGheGiuChoQLCB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaCho",
                table: "DatCho");

            migrationBuilder.AddColumn<int>(
                name: "MaChoID",
                table: "DatCho",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GheGiuCho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GheGiuCho", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GheGiuCho");

            migrationBuilder.DropColumn(
                name: "MaChoID",
                table: "DatCho");

            migrationBuilder.AddColumn<string>(
                name: "MaCho",
                table: "DatCho",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
