using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cine.Models;
using Cine.ModelsRepository;
using Cine.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Cine.Controllers
{
    public class TheaterUserController : Controller
    {
        private readonly UserManager<TheaterUser> _userManager;
        private readonly SignInManager<TheaterUser> _signInManager;
        private readonly ITheaterMemberRepository _theaterMemberRepository;
        
        
        public TheaterUserController(UserManager<TheaterUser> userManager,
                                    SignInManager<TheaterUser> signInManager,
                                    ITheaterMemberRepository theaterMemberRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _theaterMemberRepository = theaterMemberRepository;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new TheaterUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Card = model.Card
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "main");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "main");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                    return RedirectToAction("index", "main");

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        
        public async Task<IActionResult> BecomeClubMember()
        {
            TheaterUser user = await _userManager.GetUserAsync(@User);
            _theaterMemberRepository.Add(user);
            return RedirectToAction("index", "main");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TheaterUser user)
        {
            await _userManager.CreateAsync(user);
            return RedirectToAction("UserList", "TheaterUser");
        }
        
        public IActionResult UserList()
        {
            IEnumerable<TheaterUser> users = _userManager.Users;
            ViewBag.Users = users;
            ViewBag.UsersCount = users == null ? 0 : users.Count();
            return View();
        }

        public IActionResult MainProfile()
        {
            return View();
        }
    }
}