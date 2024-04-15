using System;
namespace H5ServersideToDoList.Services
{
    public interface IHashingService
    {
        public string MD5Hashing(string input);
        public string SHAHashing(string input);
        public string HMCHashing(string input);
        public string PBKDF2Hashing(string input);
        public string BCryptHashing(string input);
        public bool BCryptHashValidator(string input, string hashedValue);
    }
}

