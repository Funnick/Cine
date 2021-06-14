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
    public class MovieController : Controller
    {
        private readonly IGetRepository<Movie> _movieRepository;
        private readonly IGetRepository<Director> _directorRepository;
        private readonly IGetRepository<Actor> _actorRepository;

        public MovieController(IGetRepository<Movie> movieRepository,
            IGetRepository<Director> directorRepository,
            IGetRepository<Actor> actorRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _actorRepository = actorRepository;
        }

        [HttpPost]
        public IActionResult Create(Movie obj)
        {
            _movieRepository.Add(obj);
            return RedirectToAction("MovieList", "Movie");
        }
        
        public IActionResult MovieList()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            IEnumerable<Actor> actors = _actorRepository.GetAllObj();
            IEnumerable<Director> directors = _directorRepository.GetAllObj();
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            ViewBag.Directors = directors;
            ViewBag.DirectorsCount = directors?.Count() ?? 0;
            ViewBag.Actors = actors;
            ViewBag.ActorsCount = actors?.Count() ?? 0;
            return View();
        }
        //Regular user view (Main)
        public IActionResult MainMovies()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies == null ? 0 : movies.Count();
            return View();
        }
    }
}