﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Custom_Filters.Models;
using System.Security.Claims;
using Custom_Filters.Models;

namespace Phase3Section2._12.Controllers
{
    [ActionLoggingFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        [AllowAnonymous]
        public ViewResult StudentView()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();

        }

        [Authorize]
        public ViewResult StudentViewSecure()
        {
            return View();

        }

        public IActionResult HomeLoginAction()
        {
            string userName = "admin";

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("StudentViewSecure", "Home");
        }
    }
}