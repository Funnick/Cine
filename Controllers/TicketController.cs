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
    public class TicketController : Controller
    {
        private readonly IGetRepository<Ticket> _ticketRepository;
        private readonly IGetRepository<Discount> _discountRepository;
        private readonly IGetRepository<Show> _showRepository;
        private readonly ITheaterUserRepository _userRepository;

        public TicketController(IGetRepository<Ticket> ticketRepository, 
            IGetRepository<Discount> discountRepository,
            IGetRepository<Show> showRepository,
            ITheaterUserRepository userRepository)
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
            return RedirectToAction("TicketList", "Ticket");
        }
        
        public IActionResult TicketList()
        {
            IEnumerable<Ticket> tickets = _ticketRepository.GetAllObj();
            ViewBag.Tickets = tickets;
            ViewBag.TicketCount = tickets?.Count() ?? 0;
            IEnumerable<Discount> discounts = _discountRepository.GetAllObj();
            ViewBag.Discounts = discounts;
            ViewBag.DiscountsCount = discounts?.Count() ?? 0;
            IEnumerable<Show> shows = _showRepository.GetAllObj();
            ViewBag.Shows = shows;
            ViewBag.ShowsCount = shows?.Count() ?? 0;
            IEnumerable<TheaterUser> users = _userRepository.GetAllTheaterUser();
            ViewBag.TheaterUsers = users;
            ViewBag.TheaterUsersCount = users?.Count() ?? 0;
            return View();
        }
    }
}