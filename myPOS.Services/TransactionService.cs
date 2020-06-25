using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myPOS.Data.Context;
using myPOS.Entities;
using myPOS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myPOS.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly MyDbContext _context;
        private readonly UserManager<User> _userManager;
        public TransactionService(MyDbContext context, UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task<ICollection<UsersTransactions>> ReturnTransactions(ClaimsPrincipal user)
        {
            var loggedUser = await _userManager.GetUserAsync(user);
            if (loggedUser != null)
            {

                var isAdmin = await _userManager.IsInRoleAsync(loggedUser, "Administrator");

                if (isAdmin)
                {
                    return await _context.UsersTransactions.Include(x => x.UserFrom).Include(x => x.UserTo).ToListAsync();
                }

                return await _context.UsersTransactions.Include(x => x.UserFrom).Include(x => x.UserTo).Where(x => x.UserFrom == loggedUser || x.UserTo == loggedUser).ToListAsync();
            }
            return null;
        }
        public async Task<UsersTransactions> TranferMoneyAsync(string comment, double credits, User userFrom, User userTo)
        {
            userFrom.Balance -= credits;
            userTo.Balance += credits;
            var transaction = new UsersTransactions
            {
                Id = new Guid(),
                Comment = comment,
                TransactionAmount = credits,
                UserFrom = userFrom,
                UserTo = userTo
            };
            this._context.Update(userFrom);
            this._context.Update(userTo);
            await _context.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
