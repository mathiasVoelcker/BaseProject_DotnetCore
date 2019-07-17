using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.Interfaces;
using BaseProject.Model;

namespace BaseProject.Domain.Applications
{
    public class DefaultValueApplication : IDefaultValueApplication
    {
        private IDefaultValueRepository _repository;

        public DefaultValueApplication(IDefaultValueRepository repository) {
            _repository = repository;
        }

        public async Task<bool> Create(DefaultValue defaultValue)
        {
            
            return await _repository.Create(defaultValue);
                
        }

        public async Task<List<DefaultValue>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}