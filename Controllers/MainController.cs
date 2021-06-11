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
        //private readonly ILogger<MainController> _logger;
        private readonly int _RegistrysPerPage = 10 ;
        private readonly CineDbContext _DbContext;
        public MainController(CineDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        private List<Cine.Models.Movie> _Movies;
        private GenericPaginator<Cine.Models.Movie> _MoviePaginator;

        //public MainController(ILogger<MainController> logger)
        //{
        //    _logger = logger;
        //}
        
        public IActionResult Index(int page = 1)
        {
            int _TotalRegistry = 0;

            // Número total de registros de la tabla Customers
            _TotalRegistry = _DbContext.Movies.Count();
            // Obtenemos la 'página de registros' de la tabla Customers
            _Movies = _DbContext.Movies.OrderBy(x => x.Title)
                                             .Skip((page - 1) * _RegistrysPerPage)
                                             .Take(_RegistrysPerPage)
                                             .ToList();
            // Número total de páginas de la tabla Customers
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




            //return View();
        }
        public IActionResult Shows()
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
