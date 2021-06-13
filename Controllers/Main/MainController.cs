using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Cine.Models;
using Cine.Tools;

namespace Cine.Controllers
{
    public class MainController : Controller
    {
        
        private readonly int _RegistrysPerPage = 10 ;
        private readonly CineDbContext _DbContext;
        private  List<Cine.Models.Movie> _Movies;

        public MainController(CineDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Films(int page = 1, string search_by = "Title", string order_by = "Title", string search = "")
        {
            GenericPaginator<Cine.Models.Movie> _MoviePaginator;
            
            int _TotalRegistry = _DbContext.Movies.Count();
            if (search_by == "Title")_Movies = _DbContext.Movies.Where(x => x.Title.StartsWith(search)).ToList();
            else if (search_by == "Country") _Movies = _DbContext.Movies.Where(x => x.Country.StartsWith(search)).ToList();
            else if (search_by == "Category") _Movies = _DbContext.Movies.Where(x => x.Category.StartsWith(search)).ToList();

            if (order_by == "Title")
                _Movies = _DbContext.Movies.OrderBy(x => x.Title)
                                         .Skip((page - 1) * _RegistrysPerPage)
                                         .Take(_RegistrysPerPage)
                                         .ToList();
            
            else if (order_by == "Year")
                _Movies = _DbContext.Movies.OrderBy(x => x.Year)
                                         .Skip((page - 1) * _RegistrysPerPage)
                                         .Take(_RegistrysPerPage)
                                         .ToList();
            
            else if (order_by == "Duration")
                _Movies = _DbContext.Movies.OrderBy(x => x.Duration)
                                         .Skip((page - 1) * _RegistrysPerPage)
                                         .Take(_RegistrysPerPage)
                                         .ToList();


            var _TotalPages = (int)Math.Ceiling((double)_TotalRegistry / _RegistrysPerPage);
            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _MoviePaginator = new GenericPaginator<Cine.Models.Movie>()
            {
                RegistrysPerPage = _RegistrysPerPage,
                TotalRegistrys = _TotalRegistry,
                TotalPages = _TotalPages,
                ActualPage = page,
                Result = _Movies
            };
            // Enviamos a la Vista la 'Clase de paginación'
            return View(_MoviePaginator);
        }
        

        public IActionResult Shows( int page = 1, string search_by = "Title", string order_by = "Title", string search = "")
        {
            return View();
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
