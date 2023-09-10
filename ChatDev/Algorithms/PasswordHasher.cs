using Konscious.Security.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ChatDev.Algorithms
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hasher.GetBytes(32)); // 32 bytes is a good choice for password hashing
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
