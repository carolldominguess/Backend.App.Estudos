using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mttechne.Backend.Junior.Infra.Context;
using System.Data;

namespace Mttechne.Backend.Junior.Infra.Data
{
    /// <summary>
    /// ContextFactory  para o EF realizar instancias do contexto no banco de dados conforme as operações de migrações 
    /// em tempo de design, garantindo que o EF tenha acesso às configurações corretas, ao executar os comandos de design.
    /// </summary>
    public class MttechneDbContextFactory : IDesignTimeDbContextFactory<MttechneDbContext>
    {
        private readonly string connectionString = "Server=(localDb)\\MSSQLLocalDB;Database=Mttechne.Backend.Junior;Trusted_Connection=True;MultipleActiveResultSets=true";

        public MttechneDbContextFactory()
        {
                
        }
        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }


        public MttechneDbContext CreateDbContext(string[] args)
        {
            // Configura o DbContextOptionsBuilder com a string de conexão
            var optionsBuilder = new DbContextOptionsBuilder<MttechneDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MttechneDbContext(optionsBuilder.Options);
        }
    }
}
