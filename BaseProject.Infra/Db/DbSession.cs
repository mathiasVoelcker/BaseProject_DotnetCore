using System.Data.SqlClient;
using BaseProject.Infra.Interfaces;

namespace BaseProject.Infra.Db
{
    public class DbSession : IDbSession
    {
        private string _connectionString;

        public DbSession(string connectionString) {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection() {
            return new SqlConnection(_connectionString);
        }
    }
}