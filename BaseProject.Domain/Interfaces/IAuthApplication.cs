using System.Threading.Tasks;
using BaseProject.Infra.Security;
using BaseProject.Model;
using BaseProject.Model.DTOs;

namespace BaseProject.Domain.Interfaces
{
    public interface IAuthApplication
    {
        Task<string> Login(LoginDto loginDto);

        Task<bool> Register(RegisterDto registerDto);
    }
}