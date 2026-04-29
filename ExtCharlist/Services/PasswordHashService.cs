using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ExtCharlistAPI.Services
{
    public class PasswordHashService
    {

        public async Task<(string, byte[])> HashPasswordAsync(string password)
        {

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return (hashed, salt);
        }
        public async Task<bool> VerifyPasswordAsync(string password, string hashedPassword, byte[] salt)
        {
            // In a real application, you would retrieve the salt from the database along with the hashed password
            string hashedInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedInput == hashedPassword;
        }
    }
    }

