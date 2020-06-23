using Microsoft.EntityFrameworkCore;
using myPOS.Data.Context;
using myPOS.Entities;
using myPOS.Services.Contracts;
using myPOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPOS.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly myDbContext _context;
        public TransactionService(myDbContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<TransactionViewModel>> ReturnTransactions()
        {
            var query = await this._context.UsersTransactions.Include(x => x.UserFrom).Include(x => x.UserTo).
                Select(x => new TransactionViewModel()
                {
                    Comment = x.Comment,
                    PhoneNumber = x.UserTo.PhoneNumber,
                    TransactionFrom = x.UserFrom,
                    TransactionTo = x.UserTo,
                    Credits = x.TransactionAmount,
                    Id = x.Id
                })
                .ToListAsync();

            return query;
        }

        public async Task<ICollection<TransactionViewModel>> ReturnUserTransactions(string userId)
        {
            var query = await this._context.UsersTransactions.Include(x => x.UserFrom).Include(x => x.UserTo).Where(x => x.UserToId == userId).
               Select(x => new TransactionViewModel() { Comment = x.Comment,
                   PhoneNumber = x.UserTo.PhoneNumber,
                   TransactionFrom = x.UserFrom,
                   TransactionTo = x.UserTo,
                   Credits = x.TransactionAmount,
                   Id = x.Id }).ToListAsync();

            return query;
        }

        public async Task<UsersTransactions> TranferMoneyAsync(TransactionViewModel transactionViewModel)
        {
            var userFrom = transactionViewModel.TransactionFrom;
            var userTo = transactionViewModel.TransactionTo;

            userFrom.Balance -= transactionViewModel.Credits;
            userTo.Balance += transactionViewModel.Credits;
            var transaction = new UsersTransactions
            {
                Id = new Guid(),
                Comment = transactionViewModel.Comment,
                TransactionAmount = transactionViewModel.Credits,
                UserFrom = transactionViewModel.TransactionFrom,
                UserTo = transactionViewModel.TransactionTo
            };
            this._context.Update(userFrom);
            this._context.Update(userTo);
            await _context.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}
