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
            return RedirectToAction("DiscountList", "Discount");
        }
        
        public IActionResult DiscountList()
        {
            IEnumerable<Discount> discounts = _discountRepository.GetAllObj();
            ViewBag.Discounts = discounts;
            ViewBag.DiscountsCount = discounts == null ? 0 : discounts.Count();
            return View();
        }
    }
}