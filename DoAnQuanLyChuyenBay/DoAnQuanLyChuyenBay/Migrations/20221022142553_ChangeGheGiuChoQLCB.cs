using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnCB.API.Migrations
{
    public partial class ChangeGheGiuChoQLCB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaChoID",
                table: "DatCho");

            migrationBuilder.AddColumn<int>(
                name: "DatChoId",
                table: "GheGiuCho",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatChoId",
                table: "GheGiuCho");

            migrationBuilder.AddColumn<int>(
                name: "MaChoID",
                table: "DatCho",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
