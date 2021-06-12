using System;
using System.Linq;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetRepository<TheaterUser> _userRepository;
        // GET
        public UserController(IGetRepository<TheaterUser> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create(TheaterUser obj)
        {
            _userRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }
        public IActionResult UserList()
        {
            Console.WriteLine(_userRepository.GetAllObj().Count());
            Console.WriteLine("2");
            ViewBag.Members = _userRepository.GetAllObj();
            return View();
        }
    }
}