using System;
using H5ServersideToDoList.Data;
using H5ServersideToDoList.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5ServersideToDoList.Services
{
	public class ToDoService : IToDoService
	{
        private readonly DataDBContext _dataDbContext;
        private readonly ApplicationDbContext _context;
        private readonly IHashingService _hashingService;
        private readonly IAsymmetricEncryptionService _encryptionService;

        public ToDoService(DataDBContext dataDbContext, ApplicationDbContext context, IHashingService hashingService, IAsymmetricEncryptionService encryptionService)
		{
            _dataDbContext = dataDbContext;
            _context = context;
            _hashingService = hashingService;
            _encryptionService = encryptionService;
        }

		public async Task<bool> AddTask(string userMail, string title)
		{
            string userId = _context.Users.Where(x => x.NormalizedEmail == userMail.ToUpper()).FirstOrDefault().Id;

            string encryptedTitle = _encryptionService.EncryptAsymmetric(title);

            ToDoItem item = new ToDoItem { IdentityId = Guid.Parse(userId), Title = encryptedTitle };

            _dataDbContext.TodoItems.Add(item);

            return await Save();
        }

        public async Task<List<ToDoItem>> GetToDoItems(string userMail)
        {
            string userId = _context.Users.Where(x => x.NormalizedEmail == userMail.ToUpper()).FirstOrDefault().Id;


            List<ToDoItem> items = await _dataDbContext.TodoItems.Where(x => x.IdentityId == Guid.Parse(userId)).ToListAsync();

            var decryptedTasks = items.Select(x => new ToDoItem { Id = x.Id, IdentityId = x.IdentityId, Title = _encryptionService.DecryptAsymmetric(x.Title)}).ToList();

            return decryptedTasks;
        }

        public async Task<bool> Save()
        {
            return await _dataDbContext.SaveChangesAsync() > 0;
        }
    }
}

