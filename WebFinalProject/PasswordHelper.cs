using System.Text;
using System.Security.Cryptography;

namespace WebFinalProject
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashedBytes = sha512.ComputeHash(passwordBytes);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    stringBuilder.Append(b.ToString("X2"));
                }

                string hashedPassword = stringBuilder.ToString();

                return hashedPassword;
            }
        }
    }
}