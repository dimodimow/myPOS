using myPOS.Entities;
using myPOS.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myPOS.Services.Contracts
{
    public interface ITransactionService
    {
        public Task<UsersTransactions> TranferMoneyAsync(TransactionViewModel transactionViewModel);
        public Task<ICollection<TransactionViewModel>> ReturnTransactions();
        public Task<ICollection<TransactionViewModel>> ReturnUserTransactions(string userId);
    }
}
