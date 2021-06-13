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

        public ProducerController(IGetRepository<Actor> actorRepository,
            IGetRepository<Director> directorRepository)
        {
            _actorRepository = actorRepository;
            _directorRepository = directorRepository;
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
            ViewBag.Actors = actors;
            ViewBag.Directors = directors;
            ViewBag.ActorsCount = actors == null ? 0 : actors.Count();
            ViewBag.DirectorsCount = directors == null ? 0 : directors.Count();
            return View();
        }
    }
}