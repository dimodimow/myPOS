using myPOS.Entities;
using myPOS.Web.Mappers.Contracts;
using myPOS.Web.Models;

namespace myPOS.Web.Mappers
{
    public class UserTransactionMapper : IMapper<TransactionViewModel, UsersTransactions>
    {
        public TransactionViewModel Map(UsersTransactions entity)
        {
            return new TransactionViewModel
            {
                Id = entity.Id,
                Comment = entity.Comment,
                Credits = entity.UserFrom.Balance,
                CreatedOn = entity.CreatedOn,
                PhoneNumber = entity.UserFrom.PhoneNumber,
                TransactionFrom = entity.UserFrom,
                TransactionTo = entity.UserTo,
            };
        }
    }
}
