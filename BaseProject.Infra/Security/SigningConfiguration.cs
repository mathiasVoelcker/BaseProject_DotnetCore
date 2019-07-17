using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace BaseProject.Infra.Security
{
    public class SigningConfiguration
    {
        public SigningConfiguration()
        {
            using(var provider = new RSACryptoServiceProvider(2048)) {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            Credentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
        public SecurityKey Key { get; }

        public SigningCredentials Credentials { get; set; }
    }
}