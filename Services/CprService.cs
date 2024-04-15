using System;
using H5ServersideToDoList.Data;
using H5ServersideToDoList.Data.Models;
using H5ServersideToDoList.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace H5ServersideToDoList.Services
{
    public class CprService : ICprService
    {
        private readonly DataDBContext _dataDbContext;
        UserManager<ApplicationUser> _userManager;
        private readonly IHashingService _hashingService;


        public CprService(DataDBContext dataDbContext, IServiceProvider serviceProvider, IHashingService hashingService)
        {
            _dataDbContext = dataDbContext;
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _hashingService = hashingService;
        }

        public async Task<bool> AddCprToUser(string cpr, string userMail)
        {
            try
            {
                bool exists = await IsExisting(userMail);

                var hashedCpr = _hashingService.BCryptHashing(cpr);

                if (!exists)
                {
                    ApplicationUser? appUser = await _userManager.FindByEmailAsync(userMail.ToUpper());

                    if (appUser != null)
                    {

                        Cpr cprRecord = new Cpr { IdentityId = Guid.Parse(appUser.Id), CprNumber = hashedCpr, UserMail = userMail };
                        _dataDbContext.Cprs.Add(cprRecord);
                        return await Save();
                    }
                }

            }
            catch (Exception err)
            {
                throw new Exception($"{userMail}", err);
            }


            return true;

        }

        private async Task<bool> IsExisting(string email)
        {
            return await _dataDbContext.Cprs.AnyAsync(x => x.UserMail.ToLower() == email.ToLower());
        }

        public async Task<bool> Save()
        {
            return await _dataDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> CheckExisitingCpr(string userMail)
        {
            return await _dataDbContext.Cprs.AnyAsync(x => x.UserMail.ToLower() == userMail.ToLower());
        }

        public async Task<bool> CheckMatchingCpr(string cpr, string userMail)
        {
            Cpr cpr1 = await _dataDbContext.Cprs.FirstAsync(x => x.UserMail == userMail);

            bool cprValidated = _hashingService.BCryptHashValidator(cpr, cpr1.CprNumber);

            return cprValidated;
        }

    }
}

