using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.Model;

namespace BaseProject.Infra.Interfaces
{
    public interface IDefaultValueRepository
    {
        Task<List<DefaultValue>> GetAll();

        Task<bool> Create(DefaultValue defaultValue);
    }
}