using Cine.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Controllers
{
    public class MainController : Controller
    {
        private readonly CineDbContext _db;
        public MainController(CineDbContext db)
        {
            _db = db;
        }
        public IActionResult Main()
        {
            IEnumerable<Show> shows = _db.Shows;    
            return View(shows);
        }
        

    }
}
