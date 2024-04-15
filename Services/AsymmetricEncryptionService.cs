using System;
using System.Security.Cryptography;

namespace H5ServersideToDoList.Services
{
    public class AsymmetricEncryptionService : IAsymmetricEncryptionService
    {
        private string _privateKey;
        private string _publicKey;

        public AsymmetricEncryptionService()
        {

            if (!(File.Exists("privateKey.pem") && File.Exists("publicKey.pem")))
            {

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    _privateKey = rsa.ToXmlString(true);
                    _publicKey = rsa.ToXmlString(false);

                    File.WriteAllText("privateKey.pem", _privateKey);
                    File.WriteAllText("publicKey.pem", _publicKey);
                }
            }
            else
            {
                _privateKey = File.ReadAllText("privateKey.pem");
                _publicKey = File.ReadAllText("publicKey.pem");
            }
        }

        public string EncryptAsymmetric(string input)
        {
            return Encryption.Encrypt(input, _publicKey);
        }

        public string DecryptAsymmetric(string input)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privateKey);

                byte[] byteArrayInput = Convert.FromBase64String(input);
                byte[] decryptedData = rsa.Decrypt(byteArrayInput, true);

                return System.Text.Encoding.UTF8.GetString(decryptedData);

            }
        }
    }
}

