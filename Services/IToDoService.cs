using System;
using H5ServersideToDoList.Data.Models.Entities;

namespace H5ServersideToDoList.Services
{
	public interface IToDoService
	{
        public Task<bool> AddTask(string userMail, string title);
        public Task<List<ToDoItem>> GetToDoItems(string userMail);
    }
}

