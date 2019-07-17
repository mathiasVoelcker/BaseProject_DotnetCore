using System;
using System.Threading.Tasks;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.Security;
using BaseProject.Model;
using BaseProject.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private IAuthApplication _authApplication;

        public AuthController(IAuthApplication authApplication) {
            _authApplication = authApplication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto login) {
            var token = await _authApplication.Login(login);
            return Ok(new {
                authenticated = true,
                accessToken = token,
                message = "OK"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto) {
            try {
                await _authApplication.Register(registerDto);
                return Ok("User Successfully Registered");
            } catch(Exception ex) {
                return BadRequest(new { ex.Message });
            }
        }
    }
}