using System;
using System.Linq;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class ProducerController : Controller
    {
        // GET
        private readonly IGetRepository<Producer> _producerRepository;

        public ProducerController(IGetRepository<Producer> producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [HttpPost]
        public IActionResult Create(Producer obj)
        {
            _producerRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }
        public IActionResult ProducerList()
        {
            Console.WriteLine(_producerRepository.GetAllObj().Count());
            Console.WriteLine("2");
            ViewBag.Producers = _producerRepository.GetAllObj();
            return View();
        }
    }
}