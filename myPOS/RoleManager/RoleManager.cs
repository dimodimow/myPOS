using Microsoft.AspNetCore.Identity;
using myPOS.Data.Context;
using myPOS.Web.RoleManager.Contract;
namespace myPOS.Web.RoleManager
{
    public class RoleManager : IRoleManager
    {
        private readonly myDbContext _context;
        public RoleManager(myDbContext context)
        {
            this._context = context;
        }
        public void RegisterUserRoleAsync(string userId, string roleId)
        {
            var userRole = new IdentityUserRole<string> { UserId = userId, RoleId = roleId };
            _context.Add(userRole);
        }
    }
}
