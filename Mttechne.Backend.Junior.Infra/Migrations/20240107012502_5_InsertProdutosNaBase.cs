using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

#nullable disable

namespace Mttechne.Backend.Junior.Infra.Migrations
{
    public partial class _5_InsertProdutosNaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Obtém o caminho do diretório da biblioteca de classes
            var libraryPath = Path.GetFullPath(Assembly.GetExecutingAssembly().Location);

            // Caminho relativo ao diretório do projeto
            var relativePath = Path.Combine("SQL", "insert_produtos.sql");

            // Caminho completo para o arquivo SQL
            var filePath = Path.Combine(relativePath);

            // Lê o conteúdo do arquivo
            var sqlScript = File.ReadAllText(filePath);

            // Executa o script SQL
            migrationBuilder.Sql(sqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
