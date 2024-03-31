using Microsoft.AspNetCore.Http;
using CRM.WEB.Data;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult List()
        {
            var events = from ev in dbContext.Events
                         join gr in dbContext.Groups on ev.GroupId equals gr.Id
                         join co in dbContext.Courses on ev.CourseId equals co.Id
                         join cl in dbContext.Сlassrooms on ev.AudiId equals cl.Id
                         join te in dbContext.Teachers on ev.TeacherId equals te.Id
                         select new EventDetailView
                         {
                             eevent = ev,
                             gro = gr,
                             course = co,
                             teacher = te,
                             сlassroom = cl
                         };
            ViewBag.time = new List<string> { "8:20", "9:50", "10:00", "11:35", "12:05", "13:40", "13:50", "15:25",
                "13:50", "15:25", "17:20", "18:40", "18:45", "20:05", "20:10", "21:30" };
            return View(events);
        }
        public ActionResult StudentList()
        {
            return View();
        }
        public ActionResult TeacherList()
        {
            return View();
        }
        public ActionResult GroupList()
        {
            return View();
        }
        public ActionResult CourseList()
        {
            return View();
        }
        public ActionResult ClassromList()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
