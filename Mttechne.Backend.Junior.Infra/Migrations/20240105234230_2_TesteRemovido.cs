using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mttechne.Backend.Junior.Infra.Migrations
{
    public partial class _2_TesteRemovido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "TB_PRODUTOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "TB_PRODUTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
