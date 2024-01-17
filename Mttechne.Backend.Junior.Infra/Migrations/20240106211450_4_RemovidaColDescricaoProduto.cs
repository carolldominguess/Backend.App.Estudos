using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mttechne.Backend.Junior.Infra.Migrations
{
    public partial class _4_RemovidaColDescricaoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRICAO_PRODUTO",
                table: "TB_PRODUTOS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO_PRODUTO",
                table: "TB_PRODUTOS",
                type: "varchar(500)",
                nullable: true);
        }
    }
}
