using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SistemaFinanciero.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
