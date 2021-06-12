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

        public ShowController(IGetRepository<Show> showRepository, IGetRepository<Cinema> cinemaRepository, IGetRepository<Movie> movieRepository)
        {
            _showRepository = showRepository;
            _cinemaRepository = cinemaRepository;
            _movieRepository = movieRepository;
        }
        /*
        [HttpGet]
        public IActionResult CreateShow()
        {
            return View();
        }
        */
        [HttpPost]
        public IActionResult Create(Show obj)
        {
            _showRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }
        public IActionResult ShowList()
        {
            Console.WriteLine(_showRepository.GetAllObj().Count());
            Console.WriteLine("2");
            ViewBag.Shows = _showRepository.GetAllObj();
            ViewBag.Cinemas = _cinemaRepository.GetAllObj();
            ViewBag.Movies = _movieRepository.GetAllObj();
            return View();
        }
        /*
        public IActionResult ShowDetail(int id)
        {
            return View(_showRepository.GetObj(id));
        }
        
        public IActionResult ShowList()
        {
            return View(_showRepository.GetAllObj());
        }
        */
    }
}