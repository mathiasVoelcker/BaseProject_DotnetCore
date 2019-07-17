using System;
using System.Threading.Tasks;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.Interfaces;
using BaseProject.Infra.Security;
using BaseProject.Model;
using BaseProject.Model.DTOs;

namespace BaseProject.Domain.Applications
{
    public class AuthApplication : IAuthApplication
    {
        private IAuthRepository _authRepository;

        public AuthApplication(IAuthRepository authRepository) {
            _authRepository = authRepository;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _authRepository.GetUser(loginDto.Username);
            if (user == null)
                throw new Exception("User not found or password does not match");
            
            if (!LoginDomain.VerifyPassword(loginDto.Password, user.Password, user.Salt))
                throw new Exception("User not found or password does not match");

            var token = _authRepository.CreateToken(user);

            return token;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            try {
                byte[] passwordHash, salt;
                if (_authRepository.GetUser(registerDto.Username) != null)
                    throw new Exception("This username is already registered");
                LoginDomain.CreatePasswordHash(registerDto.Password, out passwordHash, out salt);
                var user = new User() {
                    Username = registerDto.Username,
                    Password = passwordHash,
                    Salt = salt
                };
                await _authRepository.Register(user);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}