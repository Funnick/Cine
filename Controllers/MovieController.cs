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
            _movieRepository.Add(obj);
            foreach (var actor in createform["Actors"])
            {
                _participateRepository.Add(new Participate() { MovieId = obj.MovieId, ProducerId = int.Parse(actor)});
                obj.Actors.Add(_actorRepository.GetObj(int.Parse(actor)));
                Actor act = _actorRepository.GetObj(int.Parse(actor));
                if (!(act.Movies is null))
                    act.Movies.Add(obj);
                else act.Movies = new List<Movie>(){obj};
            }
            foreach (var director in createform["Directors"])
            {
                _participateRepository.Add(new Participate() { MovieId = obj.MovieId, ProducerId = int.Parse(director)});
                obj.Directors.Add(_directorRepository.GetObj(int.Parse(director)));
                Director dir = _directorRepository.GetObj(int.Parse(director));
                if (!(dir.Movies is null))
                    dir.Movies.Add(obj);
                else dir.Movies = new List<Movie>(){obj};
            }
            _movieRepository.Update(obj);
            return RedirectToAction("MovieList", "Movie");
        }
        public IActionResult Update(Movie obj, IFormCollection updateform)
        {
            obj.Actors = new List<Actor>();
            foreach (var actor in updateform["Actors"])
            {
                //_participateRepository.Add(new Participate() { MovieId = obj.MovieId, ProducerId = int.Parse(actor)});
                obj.Actors.Add(_actorRepository.GetObj(int.Parse(actor)));
                Actor act = _actorRepository.GetObj(int.Parse(actor));
                if(act.Movies != null && !act.Movies.Contains(obj)) act.Movies.Add(obj);
            }
            obj.Directors = new List<Director>();
            foreach (var director in updateform["Directors"])
            {
                //_participateRepository.Add(new Participate() { MovieId = obj.MovieId, ProducerId = int.Parse(director)});
                obj.Directors.Add(_directorRepository.GetObj(int.Parse(director)));
                Director dir = _directorRepository.GetObj(int.Parse(director));
                if(dir.Movies != null && !dir.Movies.Contains(obj)) dir.Movies.Add(obj);
            }
            _movieRepository.Update(obj);
            return RedirectToAction("MovieList", "Movie");
        }
        
        public IActionResult MovieList()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAllObj();
            ViewBag.Movies = movies;
            ViewBag.MoviesCount = movies?.Count() ?? 0;
            IEnumerable<Actor> actors = _actorRepository.GetAllObj();
            ViewBag.Actors = actors;
            ViewBag.ActorsCount = actors?.Count() ?? 0;
            IEnumerable<Director> directors = _directorRepository.GetAllObj();
            ViewBag.Directors = directors;
            ViewBag.DirectorsCount = directors?.Count() ?? 0;
            
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