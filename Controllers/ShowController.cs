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
            bool[] seats = new bool[cinema.NumberOfSeats];
            for (int i = 0; i < cinema.NumberOfSeats; i++)
                seats[i] = true;
            foreach (var t in  tickets)
                seats[t.SeatNumber] = false;
            ViewBag.Seats = seats;
            return View(s);
        }
        [HttpPost]
        public IActionResult MainShowDetails(IFormCollection seatsform)
        {
            int withDiscounts = 0;
            if (seatsform.Keys.Contains("discount")) withDiscounts = int.Parse(seatsform["discount"]);
            int showId = int.Parse(seatsform["id"]);
            List<int> seats = new List<int>();
            int item = 0;
            foreach(var t in seatsform.Keys)
            {
                if (Int32.TryParse(t, out item))
                {
                    seats.Add(item);
                }
            }   
            
            //En seats estan los ints de los asientos whitdiscount la cantidad de tickets q tiene descuentos y el showid del show
            Show show = _showRepository.GetObj(showId);
            Discount d;
            if (show.DiscountId != null)
                d = _discountRepository.GetObj(show.DiscountId);
            else
                d = null;
            foreach (var s in seats)
            {
                if (withDiscounts > 0)
                {
                    decimal percent = d.Percent;
                    Ticket newTicket = new Ticket
                    {
                        Price = show.Price - ((show.Price * percent) / 100),
                        Discount = d,
                        DiscountId = d.DiscountId,
                        SeatNumber = s,
                        Show = show,
                        ShowId = show.ShowId,
                    };
                    _ticketRepository.Add(newTicket);
                }
                else
                {
                    Ticket newTicket = new Ticket
                    {
                        Price = show.Price,
                        SeatNumber = s,
                        Show = show,
                        ShowId = show.ShowId,
                    };
                    _ticketRepository.Add(newTicket);
                }
            }


            return RedirectToAction("MainShows", "Show");
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