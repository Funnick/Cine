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
    public class MovieController : Controller
    {
        private readonly IGetRepository<Movie> _movieRepository;
        private readonly IGetRepository<Director> _directorRepository;
        private readonly IGetRepository<Actor> _actorRepository;
        private readonly IParticipantRepository _participateRepository;

        public MovieController(IGetRepository<Movie> movieRepository,
            IGetRepository<Director> directorRepository,
            IGetRepository<Actor> actorRepository,
            IParticipantRepository participateRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _actorRepository = actorRepository;
            _participateRepository = participateRepository;

        }

        [HttpPost]
        public IActionResult Create(Movie obj, IFormCollection createform)
        {
            foreach (var actor in createform["Actors"])
            {
                _participateRepository.Add(new Participate() { MovieId = obj.MovieId, ProducerId = int.Parse(actor)});
            }
            foreach (var director in createform["Actors"])
            {
                _participateRepository.Add(new Participate() { MovieId = obj.MovieId, ProducerId = int.Parse(director)});
            }

            _movieRepository.Add(obj);
            return RedirectToAction("MovieList", "Movie");
        }
        public IActionResult Update(Movie obj)
        {
            _movieRepository.Update(obj);
            return RedirectToAction("MovieList", "Movie");
        }
        
        public IActionResult MovieList()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            
            return View();
        }
        //Regular user view (Main)
        public IActionResult MainMovies(int page = 1, string search_by = "Title", string order_by = "Title", string search = "")
        {
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            if (search_by == "Title") movies = movies.Where(x => x.Title.StartsWith(search));
            else if (search_by == "Country") movies = movies.Where(x => x.Country.StartsWith(search));
            else if (search_by == "Category") movies = movies.Where(x => x.Category.StartsWith(search));
            if (order_by == "Title") movies = movies.OrderBy(x => x.Title);
            else if (order_by == "Year") movies = movies.OrderBy(x => x.Year);
            else if (order_by == "Duration") movies = movies.OrderBy(x => x.Duration);


            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies == null ? 0 : movies.Count();
            return View();
        }
    }
}