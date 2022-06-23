using System.Security.Cryptography;
using System.Text;

namespace Class_07_Encapsulation.Login
{
	public class Cryptography
    {
        private readonly HashAlgorithm Crypt;

        public Cryptography(HashAlgorithm hash)
		{
            Crypt = hash;
        }

        public string PasswordEncrypt(string password)
        {
            var encoded = Encoding.UTF8.GetBytes(password);
			byte[] encrypted = Crypt.ComputeHash(encoded);

            var builder = new StringBuilder();

            foreach (var character in encrypted)
            {
                builder.Append(character.ToString("X2"));
            }

            return builder.ToString();
        }

        public bool IsValidPassword(string informed, string correct)
        {
            var encrypted = Crypt.ComputeHash(Encoding.UTF8.GetBytes(informed));

            var builder = new StringBuilder();

            foreach (var character in encrypted)
            {
                builder.Append(character.ToString("X2"));
            }

            return builder.ToString() == correct;
        }
    }
}
