using System.Data;
using Microsoft.Data.SqlClient;

namespace dataTablesApplicationMVC.Data
{
    public class EmployeeDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public EmployeeDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = configuration?.GetConnectionString("SqlServer");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
