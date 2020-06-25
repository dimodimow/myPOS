using myPOS.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myPOS.Services.Contracts
{
    public interface ITransactionService
    {
        public Task<UsersTransactions> TranferMoneyAsync(string comment, double credits, User userFrom, User userTo);
        public Task<ICollection<UsersTransactions>> ReturnTransactions(ClaimsPrincipal user);
    }
}
