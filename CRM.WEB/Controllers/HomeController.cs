using CRM.WEB.Data;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRM.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var events = from ev in dbContext.Events
                           join gr in dbContext.Groups on ev.GroupId equals gr.Id
                           join co in dbContext.Courses on ev.CourseId equals co.Id
                           join te in dbContext.Teachers on ev.TeacherId equals te.Id
                           join cl in dbContext.Ñlassrooms on ev.ÑlassroomId equals cl.Id
                           select new EventDetailView
                           {
                               eevent = ev,
                               gro = gr,
                               course = co,
                               teacher = te,
                               ñlassroom = cl
                           };

            ViewBag.time = new List<string> { "8:20", "9:50", "10:00", "11:35", "12:05", "13:40", "13:50", "15:25",
                "13:50", "15:25", "17:20", "18:40", "18:45", "20:05", "20:10", "21:30" };
            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
