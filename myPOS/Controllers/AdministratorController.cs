using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myPOS.Entities;
using myPOS.Services.Contracts;
using myPOS.Web.Mappers.Contracts;
using myPOS.Web.Models;

namespace myPOS.Web.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IMapper<UserViewModel, User> _userMapper;
        private readonly IUserService _userService;

        public AdministratorController(IMapper<UserViewModel, User> userMapper, IUserService userService)
        {
            this._userMapper = userMapper;
            this._userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var users = await this._userService.GetAllUsers();

            var usersViewModelList = new List<UserViewModel>();
            foreach (var user in users)
            {
                usersViewModelList.Add(this._userMapper.Map(user));
            }

            return View(usersViewModelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<IActionResult> LockUser(string id)
        {
            if (this.ModelState.IsValid)
            {
                await this._userService.LockUser(id);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<IActionResult> UnlockUser(string id)
        {
            if (this.ModelState.IsValid)
            {
                await this._userService.UnlockUser(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}