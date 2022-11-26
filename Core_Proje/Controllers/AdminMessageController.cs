using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p = "nazmiaras@yahoo.com";
            var values = writerMessageManager.GetListRecieverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p = "nazmiaras@yahoo.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage s)
        {
            s.Sender = "nazmiaras@yahoo.com";
            s.SenderName = "Nazmi Aras";
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == s.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            s.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(s);
            return RedirectToAction("Index");
        }
    }
}
