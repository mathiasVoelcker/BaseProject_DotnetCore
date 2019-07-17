using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.Infra.Db.Scripts;
using BaseProject.Infra.Interfaces;
using BaseProject.Model;
using Dapper;

namespace BaseProject.Infra.Repositories
{
    public class DefaultValueRepository : BaseRepository, IDefaultValueRepository
    {
        public DefaultValueRepository(IDbSession dbSession) : base(dbSession) { }

        public async Task<bool> Create(DefaultValue defaultValue)
        {
            try {
                using (var conn = CreateConnection()) {
                    await conn.ExecuteAsync(DefaultValueScripts.Create, defaultValue);
                    return true;
                }
            } catch (Exception) {
                return false;
            }
        }

        public async Task<List<DefaultValue>> GetAll()
        {
            using (var conn = CreateConnection()) {
                var listDefaultValue = await conn.QueryAsync<DefaultValue>(DefaultValueScripts.Get);
                return listDefaultValue.AsList();
            }
        }
    }
}