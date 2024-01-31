using System.Security.Cryptography;
using System.Text;

namespace DeltaFit.Api.Infrastructure.Cryptography
{
    public static class Hashing
    {
        public static (byte[] Hash, byte[] Salt) DoCompute(string value)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
            var salt = hmac.Key;
            return (hash, salt);
        }

        public static byte[] DoCompute(string value, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
        }
    }
}
