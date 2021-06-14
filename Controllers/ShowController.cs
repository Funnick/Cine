﻿using System;
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

        public ShowController(IGetRepository<Show> showRepository,IGetRepository<Movie> movieRepository,IGetRepository<Cinema> cinemaRepository)
        {
            _showRepository = showRepository;
            _movieRepository = movieRepository;
            _cinemaRepository = cinemaRepository;
        }
        
        [HttpPost]
        public IActionResult Create(Show obj)
        {
            /*
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.Movie.Title);
                Show show = new Show
                {
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    Date = model.Date,
                    MovieId = model.MovieId,
                    Movie = _movieRepository.GetObj(model.MovieId),
                    Movie = model.Movie,
                    MovieId = model.Movie.MovieId,
                    CinemaId = model.CinemaId,
                    Cinema = _cinemaRepository.GetObj(model.CinemaId),
                    Cinema = model.Cinema,
                    CinemaId = model.Cinema.CinemaId, 
                    Price = model.Price,
                    PointsPrice = model.PointsPrice
                };
            
                _showRepository.Add(show);
            }*/
            _showRepository.Add(obj);
            return RedirectToAction("ShowList", "Show");
        }
        
        public IActionResult MainShowDetails(int id)
        {
            return View(_showRepository.GetObj(id));
        }
        
        public IActionResult ShowList()
        {
            IEnumerable<Show> shows = _showRepository.GetAllObj();
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            IEnumerable<Cinema> cinemas = _cinemaRepository.GetAllObj();
            ViewBag.Shows = shows;
            ViewBag.ShowsCount = shows?.Count() ?? 0;
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            ViewBag.Cinemas = cinemas;
            ViewBag.CinemasCount = cinemas?.Count() ?? 0;
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