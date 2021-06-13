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

        public TicketController(IGetRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
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
            ViewBag.TicketCount = tickets == null ? 0 : tickets.Count();
            return View();
        }
    }
}