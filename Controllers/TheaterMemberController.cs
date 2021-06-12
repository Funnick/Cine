using System;
using System.Linq;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class TheaterMemberController : Controller
    {
        // GET
        private readonly IGetRepository<TheaterMember> _memberRepository;

        public TheaterMemberController(IGetRepository<TheaterMember> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpPost]
        public IActionResult Create(TheaterMember obj)
        {
            _memberRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }
        public IActionResult MemberList()
        {
            Console.WriteLine(_memberRepository.GetAllObj().Count());
            Console.WriteLine("2");
            ViewBag.Members = _memberRepository.GetAllObj();
            return View();
        }
    }
}