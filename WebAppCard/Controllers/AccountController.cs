﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.DTO;
using WebAppCard.Data.Models;

namespace WebAppCard.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<StoreUser> _signInManager;

        public AccountController(ILogger<AccountController> logger,
                                    SignInManager<StoreUser> signInManager)
        {
            this._logger = logger;
            this._signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if ( this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "App");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                            .PasswordSignInAsync(
                            model.Username,
                            model.Password,
                            model.RememberMe,
                            false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Shop", "App");
                    }
                }
            }
            ModelState.AddModelError("", "Failed to login");

            return View();
        }
    }
}
