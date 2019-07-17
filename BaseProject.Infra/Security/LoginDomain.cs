using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BaseProject.Model;
using Microsoft.IdentityModel.Tokens;

namespace BaseProject.Infra.Security
{
    public static class LoginDomain
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256()) {
                salt = hmac.Key;
                var passwordByteArray = Encoding.UTF8.GetBytes(password);
                var finalHash = salt.Concat(passwordByteArray).ToArray();

                passwordHash = hmac.ComputeHash(finalHash);
            }
        }

        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(salt)) {
                
                var passwordByteArray = Encoding.UTF8.GetBytes(password);
                var finalHash = salt.Concat(passwordByteArray).ToArray();

                var computeHash = hmac.ComputeHash(finalHash);
                for (int i = 0; i < computeHash.Length; i ++) {
                    if (computeHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

    }
}