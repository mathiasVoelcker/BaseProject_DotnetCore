using System.Threading.Tasks;
using BaseProject.Model;

namespace BaseProject.Infra.Interfaces
{
    public interface IAuthRepository
    {

        Task<User> GetUser(string userName);

        Task<User> Register(User user);

        string CreateToken(User user);

        // Task<User> Login(string username, string password);

        // Task<bool> UserExists(string username);
    }
}