using System;
using System.Linq;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class TicketController : Controller
    {
        // GET
        private readonly IGetRepository<Ticket> _ticketRepository;
        private readonly IGetRepository<Discount> _discountRepository;
        private readonly IGetRepository<Show> _showRepository;
        private readonly IGetRepository<TheaterUser> _userRepository;

        public TicketController(IGetRepository<Ticket> ticketRepository, IGetRepository<Discount> discountRepository, IGetRepository<Show> showRepository, IGetRepository<TheaterUser> userRepository)
        {
            _ticketRepository = ticketRepository;
            _discountRepository = discountRepository;
            _showRepository = showRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create(Ticket obj)
        {
            _ticketRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }
        public IActionResult TicketList()
        {
            Console.WriteLine(_ticketRepository.GetAllObj().Count());
            Console.WriteLine("2");
            ViewBag.Tickets = _ticketRepository.GetAllObj();
            ViewBag.Discounts = _discountRepository.GetAllObj();
            ViewBag.Shows = _showRepository.GetAllObj();
            ViewBag.Users = _userRepository.GetAllObj();
            return View();
        }
    }
}