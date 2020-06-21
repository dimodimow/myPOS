using System;
using System.Collections.Generic;
using System.Text;

namespace myPOS.Entities
{
    public class UsersTransactions : BaseEntity
    {
        public string UserToId { get; set; }
        public string UserFromId { get; set; }
        public double TransactionAmount { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
        public string Comment { get; set; }
    }
}
