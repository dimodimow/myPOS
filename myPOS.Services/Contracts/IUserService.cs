using myPOS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myPOS.Services.Contracts
{
   public interface IUserService
    {
        Task<User> LockUser(string id);

        Task<User> UnlockUser(string id);

        //Task<bool> CheckForPhone(string phoneNumber);

        Task<List<User>> GetAllUsers();
    }
}
