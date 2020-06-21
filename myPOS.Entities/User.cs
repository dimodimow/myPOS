using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace myPOS.Entities
{
    public class User : IdentityUser
    {
        public double Balance { get; set; }
        public ICollection<UsersTransactions> TransactionFrom { get; set; }
        public ICollection<UsersTransactions> TransactionTo { get; set; }
    }
}
