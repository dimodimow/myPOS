using System;

namespace myPOS.Entities.Base.Contracts
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }
    }
}
