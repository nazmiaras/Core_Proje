using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill s)
        {
            skillManager.TAdd(s);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = skillManager.TGetByID(id);
            skillManager.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var skill = skillManager.TGetByID(id);
            return View(skill);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }

}
