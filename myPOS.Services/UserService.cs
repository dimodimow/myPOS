using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myPOS.Data.Context;
using myPOS.Entities;
using myPOS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myPOS.Services
{
   public class UserService : IUserService
    {
        private readonly MyDbContext context;
        private readonly UserManager<User> userManager;
        public UserService(MyDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<User> LockUser(string id)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if (user == null)
            {
                throw new ArgumentException("User does not exist");
            }

            await this.userManager.SetLockoutEndDateAsync(user, DateTime.Today.AddDays(200));

            return user;
        }

        public async Task<User> UnlockUser(string id)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if (user == null)
            {
                throw new ArgumentException("User does not exist");
            }

            await this.userManager.SetLockoutEndDateAsync(user, DateTime.Now);

            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await this.context.Users.ToListAsync();

            return users;
        }

    }
}
