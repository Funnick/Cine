using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    public class ManagerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}