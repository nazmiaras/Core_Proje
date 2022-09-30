using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.d1 = "Deneyimler";
            ViewBag.d2 = "Deneyim Listesi";
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.d1 = "Deneyimler";
            ViewBag.d2 = "Deneyim Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = experienceManager.TGetByID(id);
            experienceManager.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.d1 = "Deneyimler";
            ViewBag.d2 = "Deneyim Düzenle";
            var experience = experienceManager.TGetByID(id);
            return View(experience);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
