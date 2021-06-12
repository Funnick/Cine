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

        public ShowController(IGetRepository<Show> showRepository)
        {
            _showRepository = showRepository;
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
            return RedirectToAction("index", "main");
        }
       
        public IActionResult ShowList()
        {
            IEnumerable<Show> shows = _showRepository.GetAllObj();
            ViewBag.Shows = shows;
            ViewBag.ShowsCount = shows == null ? 0 : shows.Count();
            return View();
        }
    }
}