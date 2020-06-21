using myPOS.Entities.Base.Contracts;
using System;

namespace myPOS.Entities
{
   public class BaseEntity : IAuditable
    {
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
