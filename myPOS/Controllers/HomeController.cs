﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myPOS.Entities;
using myPOS.Models;
using myPOS.Services.Contracts;
using myPOS.Web.Mappers.Contracts;
using myPOS.Web.Models;

namespace myPOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper<TransactionViewModel, UsersTransactions> _transactionMapper;

        public HomeController(ILogger<HomeController> logger, UserManager<User> _userManager, ITransactionService transactionService, IMapper<TransactionViewModel, UsersTransactions> transactionMapper)
        {
            _logger = logger;
            this._userManager = _userManager;
            this._transactionService = transactionService;
            this._transactionMapper = transactionMapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var transactions = await this._transactionService.ReturnTransactions(User);
            var TransactionViewModel = new List<TransactionViewModel>();
            if (transactions != null)
            {

                foreach (var transaction in transactions)
                {
                    TransactionViewModel.Add(this._transactionMapper.Map(transaction));
                }
            }

            return View(TransactionViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(double credits, string phone, string comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var userFromId = User.Identity.Name;
            await this._transactionService.SendAsync(comment, credits, phone, userFromId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Send()
        {
            return View();
        }
    }
}
