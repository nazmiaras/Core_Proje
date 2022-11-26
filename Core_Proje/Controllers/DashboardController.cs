using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.d1 = "Anasayfa";
            ViewBag.d2 = "Dashboard";
            return View();
        }
    }
}
