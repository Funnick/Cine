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
using Microsoft.AspNetCore.Http;

namespace Cine.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IGetRepository<Show> _showRepository;
        private readonly IGetRepository<Movie> _movieRepository;
        private readonly IGetRepository<Cinema> _cinemaRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IGetRepository<Discount> _discountRepository;


        public ManagerController(IGetRepository<Show> showRepository, IGetRepository<Movie> movieRepository,
            IGetRepository<Cinema> cinemaRepository,
            ITicketRepository ticketRepository,
            IGetRepository<Discount> discountRepository)
        {
            _ticketRepository = ticketRepository;
            _showRepository = showRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _discountRepository = discountRepository;
        }
        // GET
        public IActionResult Main()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Main(IFormCollection querys)
        {
            int value = int.Parse(querys["value"]);
            switch (querys["statics_by"])
            {
                case "day":
                    var shows = _showRepository.GetAllObj();
                    var tickets = _ticketRepository.GetAllObj();
                    shows = shows.Where(x => x.Date)
                    break;



                default:
                    break;
            }

            return View();
        }
    }
}