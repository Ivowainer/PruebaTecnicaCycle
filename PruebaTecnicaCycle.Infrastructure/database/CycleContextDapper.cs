using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PruebaTecnicaCycle.Infrastructure.Database
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public string Data = "[PruebaTecnicaCycle].[Catalogo].[Productos]";

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("SQLConnection");
            return new SqlConnection(connectionString);
        }
    }
}