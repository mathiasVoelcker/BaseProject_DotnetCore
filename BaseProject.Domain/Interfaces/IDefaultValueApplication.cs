using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.Model;

namespace BaseProject.Domain.Interfaces
{
    public interface IDefaultValueApplication
    {
         Task<List<DefaultValue>> GetAll();

         Task<bool> Create(DefaultValue defaultValue);
    }
}