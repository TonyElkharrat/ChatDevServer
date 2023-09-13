using Konscious.Security.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ChatDev.Algorithms
{
    public static class PasswordHasher
    {
        private const int Iterations = 1; // You should use a higher value for production

        public static string HashPassword(string password)
        {
            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                hasher.Salt = GenerateSalt(); // You should generate a unique salt for each user
                hasher.DegreeOfParallelism = 4; // Adjust based on your server's capabilities
                hasher.MemorySize = 65536; // Adjust based on your server's capabilities and security requirements
                hasher.Iterations = Iterations; // Specify the number of iterations

                // Perform the password hashing
                byte[] hashBytes = hasher.GetBytes(32); // 32 bytes is a common size for password hashes

                // Convert the hash bytes to a hexadecimal string for storage
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hashedPassword;
            }
        }

        // You should implement a method to generate a unique salt for each user
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // You can adjust the salt size based on your needs
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

                using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
                {
                    byte[] newHashedPasswordBytes = hasher.GetBytes(hashedPasswordBytes.Length);

                    // Compare the newly generated hash with the stored hash
                    for (int i = 0; i < hashedPasswordBytes.Length; i++)
                    {
                        if (hashedPasswordBytes[i] != newHashedPasswordBytes[i])
                        {
                            return false; // Passwords don't match
                        }
                    }

                    return true; // Passwords match
                }
            }
            catch (Exception)
            {
                return false; // Hash is invalid or in an incorrect format
            }
        }


    }
}
