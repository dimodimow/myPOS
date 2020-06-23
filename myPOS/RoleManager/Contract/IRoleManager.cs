using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace myPOS.Web.RoleManager.Contract
{
    public interface IRoleManager
    {
        public void RegisterUserRoleAsync(string userId, string roleId);
    }
}