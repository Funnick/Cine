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

        public MovieController(IGetRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
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
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies == null ? 0 : movies.Count();
            return View();
        }
    }
}