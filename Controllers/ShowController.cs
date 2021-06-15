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
    public class ShowController : Controller
    {
        private readonly IGetRepository<Show> _showRepository;
        private readonly IGetRepository<Movie> _movieRepository;
        private readonly IGetRepository<Cinema> _cinemaRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IGetRepository<Discount> _discountRepository;

        public ShowController(IGetRepository<Show> showRepository,IGetRepository<Movie> movieRepository,
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
        
        [HttpPost]
        public IActionResult Create(Show obj)
        {
            _showRepository.Add(obj);
            return RedirectToAction("ShowList", "Show");
        }
        public IActionResult Update(Show obj)
        {
            _showRepository.Update(obj);
            return RedirectToAction("ShowList", "Show");
        }

        public IActionResult MainShowDetails(int id)
        {
            Show s = _showRepository.GetObj(id);
            ViewBag.Movie = _movieRepository.GetObj(s.MovieId);
            Cinema cinema = _cinemaRepository.GetObj(s.CinemaId);
            ViewBag.Cinema = cinema;
            IEnumerable<Ticket> tickets = _ticketRepository.GetShowTicekts(id);
            List<bool> seats = new List<bool>(cinema.NumberOfSeats);
            for (int i = 0; i < seats.Count; i++)
                seats[i] = true;
            foreach (var t in  tickets)
                seats[t.SeatNumber] = false;
            ViewBag.Seats = seats;
            return View(s);
        }
        
        public IActionResult ShowList()
        {
            IEnumerable<Show> shows = _showRepository.GetAllObj();
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            IEnumerable<Cinema> cinemas = _cinemaRepository.GetAllObj();
            IEnumerable<Discount> discounts = _discountRepository.GetAllObj();
            ViewBag.Shows = shows;
            ViewBag.ShowsCount = shows?.Count() ?? 0;
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            ViewBag.Cinemas = cinemas;
            ViewBag.CinemasCount = cinemas?.Count() ?? 0;
            ViewBag.Discounts = discounts;
            ViewBag.DiscountsCount = discounts?.Count() ?? 0;
            return View();
        }

        //Regular user view (Main)
        public IActionResult MainShows()
        {
            IEnumerable<Show> shows = _showRepository.GetAllObj();
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            ViewBag.Shows = shows;
            ViewBag.ShowsCount = shows?.Count() ?? 0;
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            return View();
        }
    }
}