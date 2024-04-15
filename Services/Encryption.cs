using System;
using System.Security.Cryptography;

namespace H5ServersideToDoList.Services
{
	public class Encryption
	{
		public static string Encrypt(string input, string publicKey)
		{
            using (RSACryptoServiceProvider rsa = new())
            {
                rsa.FromXmlString(publicKey);

                byte[] byteArrayInput = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] encryptedData = rsa.Encrypt(byteArrayInput, true);

                return Convert.ToBase64String(encryptedData);
            }
        }
	}
}

