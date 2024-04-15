using System;
using Microsoft.AspNetCore.DataProtection;
namespace H5ServersideToDoList.Services
{
	public class SymmetricEncryptionService
	{
		private readonly IDataProtector _protector;

		public SymmetricEncryptionService(IDataProtectionProvider protector)
		{
			_protector = protector.CreateProtector("Something");
		}

		public string EncryptData(string input)
		{
			return _protector.Protect(input);
		}

		public string DecryptData(string input)
		{
			return _protector.Unprotect(input);
		}
	}
}

