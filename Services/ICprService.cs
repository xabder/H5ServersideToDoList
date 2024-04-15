using System;
using H5ServersideToDoList.Data.Models.Entities;

namespace H5ServersideToDoList.Services
{
	public interface ICprService
	{
		public Task<bool> AddCprToUser(string cpr, string userMail);
		public Task<bool> CheckExisitingCpr(string userMail);
		public Task<bool> CheckMatchingCpr(string cpr, string userMail);
    }
}

