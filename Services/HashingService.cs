using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace H5ServersideToDoList.Services
{
    public class HashingService : IHashingService
    {
        public string MD5Hashing(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashedValue = md5.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedValue);
        }
        public string SHAHashing(string input)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashedValue = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedValue);
        }
        public string HMCHashing(string input)
        {
            byte[] myKey = Encoding.ASCII.GetBytes("KEY1");
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            HMACSHA256 hmac = new HMACSHA256();
            hmac.Key = myKey;

            byte[] hashedValue = hmac.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedValue);
        }
        public string PBKDF2Hashing(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] salt = Encoding.ASCII.GetBytes("KEY1");

            var hashAlgorithm = new HashAlgorithmName("SHA256");

            int iteration = 10;

            int outputLength = 32;

            byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(inputBytes, salt, iteration, hashAlgorithm, outputLength);

            return Convert.ToBase64String(hashedValue);
        }
        public string BCryptHashing(string input)
        {
            // return BCrypt.Net.BCrypt.HashPassword(input);

            /* -------------------------------------------------------------------------------- */

			// int workFactor = 10;
			// bool enhanceEntropy = true;

			// return BCrypt.Net.BCrypt.HashPassword(input, workFactor, enhanceEntropy);

            /* -------------------------------------------------------------------------------- */

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(input, salt, true, BCrypt.Net.HashType.SHA256);
        }

        public bool BCryptHashValidator(string input, string hashedValue)
        {

            // return BCrypt.Net.BCrypt.Verify(input, hashedValue);

            /* -------------------------------------------------------------------------------- */

            // return BCrypt.Net.BCrypt.Verify(input, hashedValue, true);

            /* -------------------------------------------------------------------------------- */

            return BCrypt.Net.BCrypt.Verify(input, hashedValue, true, BCrypt.Net.HashType.SHA256);

        }
    }
}

