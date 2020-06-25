using myPOS.Entities;
using myPOS.Web.Mappers.Contracts;
using myPOS.Web.Models;
using System;

namespace myPOS.Web.Mappers
{

    public class UserMapper : IMapper<UserViewModel, User>
    {
        public UserViewModel Map(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            return new UserViewModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                LockoutEnd = entity.LockoutEnd,
                Balance = entity.Balance
            };
        }

    }
}

