using System.Data.SqlClient;

namespace BaseProject.Infra.Interfaces
{
    public interface IDbSession
    {
        SqlConnection CreateConnection();
    }
}