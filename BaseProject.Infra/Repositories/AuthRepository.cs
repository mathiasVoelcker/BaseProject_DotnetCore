using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseProject.Infra.Db.Scripts;
using BaseProject.Infra.Interfaces;
using BaseProject.Infra.Security;
using BaseProject.Model;
using Dapper;
using Microsoft.IdentityModel.Tokens;

namespace BaseProject.Infra.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        private SigningConfiguration _signingConfig;

        private TokenConfiguration _tokenConfiguration;

        public AuthRepository(
            IDbSession dbSession, 
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfigurations) 
            : base(dbSession) { 
                _signingConfig = signingConfiguration;
                _tokenConfiguration = tokenConfigurations;
        }

        public async Task<User> GetUser(string username) {
            using (var connection = CreateConnection()) {
                var user = await connection.QueryFirstOrDefaultAsync<User>(UserScripts.Get, new { username });
                return user;
            }
        }

        public string CreateToken(User user) {
            
            var claims = new [] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var tokenDescriptor = new SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = _signingConfig.Credentials
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            using (var connection = CreateConnection()) {
                await connection.ExecuteAsync(UserScripts.Insert, user);
            }
            return user;
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}