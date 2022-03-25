using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;

namespace SomerenLogic
{
    public class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password, int saltLength, HashAlgorithm hashAlgo)
        {
            // Create new RandomNumberGenerator object
            RandomNumberGenerator rngGenerator = new RandomNumberGenerator();

            // Generate random Salt
            byte[] saltBytes = rngGenerator.GenerateRandomCryptographicBytes(saltLength);

            // Transfer password to bytes
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);

            // Create new list and set range
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);

            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());

            // Return hashed result
            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }

        public HashWithSaltResult ConvertedHashWithSalt(string password, string salt)
        {
            // Transfer password and salt to bytes
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Combine password and salt bytes into a byte list
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);

            // Create a new Hash Algorithm
            HashAlgorithm hashAlgorithm = SHA256.Create();

            // Create a hash with the list
            byte[] digestBytes = hashAlgorithm.ComputeHash(passwordWithSaltBytes.ToArray());

            // Create a new HashWithSaltResult object and return
            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }
    }
}
