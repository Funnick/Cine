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
        private readonly CineDbContext _context;


        public ManagerController(IGetRepository<Show> showRepository, IGetRepository<Movie> movieRepository,
            IGetRepository<Cinema> cinemaRepository,
            ITicketRepository ticketRepository,
            IGetRepository<Discount> discountRepository,
            CineDbContext context)
        {
            _ticketRepository = ticketRepository;
            _showRepository = showRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
            _discountRepository = discountRepository;
            _context = context;
        }
        // GET
        public IActionResult Main()
        {
            return View();
        }
        [HttpPost]
       public IActionResult Main(IFormCollection querys)
        {

            if (querys.ContainsKey("filmsCriteria"))
            {
                if (querys["filmsCriteria"] == "liked")
                {
                    IEnumerable<Show> shows = _context.Shows.OrderBy(show => _ticketRepository.GetShowTicekts(show.ShowId).Count()).Take(10);
                    List<Movie> m = new List<Movie>();
                    foreach (var s in shows)
                    {
                        m.Append(_context.Movies.Find(s.MovieId));
                    }

                    ViewBag.Query = m;
                    //Aki va la query de las 10 peliculas con mas tickets vendidios
                }
                if (querys["filmsCriteria"] == "economic")
                {
                    IEnumerable<Show> shows = _context.Shows.OrderBy(show => _ticketRepository.GetShowTicekts(show.ShowId).Count() * show.Price).Take(10);
                    List<Movie> m = new List<Movie>();
                    foreach (var s in shows)
                    {
                        m.Append(_context.Movies.Find(s.MovieId));
                    }

                    ViewBag.Query = m;
                    //Aki va la query de las 10 peliculas q mas money recaudaron
                }
            }
            if (querys.ContainsKey("statics_by"))
            {
                string value = querys["Value"];
                if(querys["statics_by"] == "category")
                {
                    IEnumerable<Show> shows = _context.Shows.OrderBy(show => _context.Movies.Find(show.MovieId).Category == value);
                    int count = 0;
                    foreach (var s in shows)
                    {
                        count += _ticketRepository.GetShowTicekts(s.ShowId).Count();
                    }

                    ViewBag.Query = count;
                    //Aqui va la query de todos los tickets q se han vendido para pelicas q su categoria 
                    //coicide con el value
                }
                if (querys["statics_by"] == "film")
                {
                    IEnumerable<Show> shows = _context.Shows.OrderBy(show => _context.Movies.Find(show.MovieId).Title == value);
                    int count = 0;
                    foreach (var s in shows)
                    {
                        count += _ticketRepository.GetShowTicekts(s.ShowId).Count();
                    }

                    ViewBag.Query = count;
                    //Aqui va la query de los tickets q se han vendido para peliculas con el titilo q esta en value
                }
                if (querys["statics_by"] == "rating")
                {
                    IEnumerable<Show> shows = _context.Shows.OrderBy(show => _ticketRepository.GetShowTicekts(show.ShowId).Count()).Take(1);
                    Show s = null;
                    foreach (var ss in  shows)
                    {
                        s = ss;
                    }
                    
                    ViewBag.Query = _ticketRepository.GetShowTicekts(s.ShowId).Count();
                    //Aki va la query de los tickets de la pelicula con mas tickets vendidos
                }
            }

            return View();
        }
    }
}