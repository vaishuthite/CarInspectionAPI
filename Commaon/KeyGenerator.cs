
using System.Security.Cryptography;
namespace CarInspectionAPI.Commaon
{
    public static class KeyGenerator
    {
        public static string GenerateRandomKey(int length = 32) // Default length is now 32 bytes
        {
            var key = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }
    }
}
