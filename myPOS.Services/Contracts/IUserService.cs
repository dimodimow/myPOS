using myPOS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myPOS.Services.Contracts
{
   public interface IUserService
    {
        Task<User> LockUser(string id);

        Task<User> UnlockUser(string id);

        Task<List<User>> GetAllUsers();
    }
}
