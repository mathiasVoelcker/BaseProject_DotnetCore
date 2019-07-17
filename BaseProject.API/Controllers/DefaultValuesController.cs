using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.Domain.Interfaces;
using BaseProject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class DefaultValuesController : ControllerBase
    {
        private IDefaultValueApplication _application;

        public DefaultValuesController(IDefaultValueApplication application) {
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<IList<DefaultValue>>> GetAll() {
            return await _application.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]DefaultValue defaultValue) { 
            await _application.Create(defaultValue);
            return Ok("Default Value Successfully Registered");
        }

    }
}