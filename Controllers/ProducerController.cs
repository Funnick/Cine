using System;
using System.Linq;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cine.Controllers
{
    public class ProducerController : Controller
    {
        // GET
        private readonly IGetRepository<Actor> _actorRepository;
        private readonly IGetRepository<Director> _directorRepository;
        private readonly IGetRepository<Movie> _movieRepository;

        public ProducerController(IGetRepository<Actor> actorRepository,
            IGetRepository<Director> directorRepository,
            IGetRepository<Movie> movieRepository)
        {
            _actorRepository = actorRepository;
            _directorRepository = directorRepository;
            _movieRepository = movieRepository;
        }

        [HttpPost]
        public IActionResult Create(Actor obj)
        {
            _actorRepository.Add(obj);
            return RedirectToAction("ProducerList", "Producer");
        }
        [HttpPost]
        public IActionResult Create(Director obj)
        {
            _directorRepository.Add(obj);
            return RedirectToAction("ProducerList", "Producer");
        }
        public IActionResult ProducerList()
        {
            IEnumerable<Actor> actors = _actorRepository.GetAllObj();
            IEnumerable<Director> directors = _directorRepository.GetAllObj();
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            ViewBag.Actors = actors;
            ViewBag.Directors = directors;
            ViewBag.Movies = movies;
            ViewBag.ActorsCount = actors?.Count() ?? 0;
            ViewBag.DirectorsCount = directors?.Count() ?? 0;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            return View();
        }
    }
}