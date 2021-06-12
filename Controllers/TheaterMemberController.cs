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
using Microsoft.EntityFrameworkCore;

namespace Cine.Controllers
{
    public class TheaterMemberController : Controller
    {
        private readonly ITheaterMemberRepository _theaterMemberRepository;

        public TheaterMemberController(ITheaterMemberRepository theaterMemberRepository)
        {
            _theaterMemberRepository = theaterMemberRepository;
        }
        
        public IActionResult MemberList()
        {
            IEnumerable<TheaterMember> members = _theaterMemberRepository.GetAllTheaterMembers();
            ViewBag.Members = members;
            ViewBag.MembersCount = members == null ? 0 : members.Count();
            return View();
        }
    }
}