using Microsoft.AspNetCore.Identity;
using myPOS.Data.Context;
using myPOS.Web.RoleManager.Contract;
namespace myPOS.Web.RoleManager
{
    public class RoleManager : IRoleManager
    {
        private readonly MyDbContext _context;
        public RoleManager(MyDbContext context)
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
