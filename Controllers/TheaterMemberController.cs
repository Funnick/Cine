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
    public class TheaterMemberController : Controller
    {
        private readonly ITheaterMemberRepository _theaterMemberRepository;
        private readonly UserManager<TheaterUser> _userManager;
        private readonly ITheaterUserRepository _userRepository;

        public TheaterMemberController(ITheaterMemberRepository theaterMemberRepository, ITheaterUserRepository userRepository, UserManager<TheaterUser> userManager)
        {
            _theaterMemberRepository = theaterMemberRepository;
            _userRepository = userRepository;
            _userManager = userManager;
        }
        
        public IActionResult MemberList()
        {
            IEnumerable<TheaterMember> members = _theaterMemberRepository.GetAllTheaterMembers();
            ViewBag.Members = members;
            ViewBag.MembersCount = members?.Count() ?? 0;
            IEnumerable<TheaterUser> users = _userRepository.GetAllTheaterUser();
            ViewBag.TheaterUsers = users;
            ViewBag.TheaterUsersCount = users?.Count() ?? 0;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TheaterUser user)
        {
            _theaterMemberRepository.Add(user);
            return RedirectToAction("MemberList", "TheaterMember");
        }
    }
}