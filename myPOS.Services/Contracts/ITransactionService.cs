using myPOS.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myPOS.Services.Contracts
{
    public interface ITransactionService
    {
        public Task<UsersTransactions> SendAsync(string comment, double credits, string phone, string username);
        public Task<ICollection<UsersTransactions>> ReturnTransactions(ClaimsPrincipal user);
    }
}
