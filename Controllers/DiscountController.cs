using System;
using System.Linq;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IGetRepository<Discount> _discountRepository;

        public DiscountController(IGetRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpPost]
        public IActionResult Create(Discount obj)
        {
            _discountRepository.Add(obj);
            return RedirectToAction("Main", "Manager");
        }
        public IActionResult DiscountList()
        {
            Console.WriteLine(_discountRepository.GetAllObj().Count());
            Console.WriteLine("2");
            ViewBag.Discounts = _discountRepository.GetAllObj();
            return View();
        }
    }
}