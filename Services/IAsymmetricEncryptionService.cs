using System;
namespace H5ServersideToDoList.Services
{
	public interface IAsymmetricEncryptionService
	{
        public string EncryptAsymmetric(string input);
        public string DecryptAsymmetric(string input);
    }
}

