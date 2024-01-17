using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mttechne.Backend.Junior.Infra.Migrations
{
    public partial class _01_MudancaColNameDtCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "TB_PRODUTOS",
                newName: "DT_CADASTRO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DT_CADASTRO",
                table: "TB_PRODUTOS",
                newName: "DataCadastro");
        }
    }
}
