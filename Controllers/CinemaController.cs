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
    public class CinemaController : Controller
    {
        private readonly IGetRepository<Cinema> _cinemaRepository;

        public CinemaController(IGetRepository<Cinema> cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
        
        [HttpPost]
        public IActionResult Create(Cinema obj)
        {
            _cinemaRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }

        public IActionResult CinemaList()
        {
            IEnumerable<Cinema> cinemas = _cinemaRepository.GetAllObj();
            ViewBag.Cinemas = cinemas;
            ViewBag.CinemasCount = cinemas == null ? 0 : cinemas.Count();
            return View();
        }
    }
}