using System.Data.SqlClient;
using BaseProject.Infra.Interfaces;

namespace BaseProject.Infra.Repositories
{
    public abstract class BaseRepository
    {
        private IDbSession _dbSession;

        public BaseRepository(IDbSession dbSession) {
            _dbSession = dbSession;
        }

        public SqlConnection CreateConnection() {
            return _dbSession.CreateConnection();
        }
        
    }
}