using CRM.WEB.Data;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRM.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var events = from ev in dbContext.Events
                           join gr in dbContext.Groups on ev.GroupId equals gr.Id
                           join co in dbContext.Courses on ev.CourseId equals co.Id
                           join te in dbContext.Teachers on co.Id equals te.CourseId
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<SelectListItem> GL = new List<SelectListItem>();
            var Glist = dbContext.Groups.ToList();
            foreach (var i in Glist)
            {
                GL.Add(new SelectListItem() { Text = i.Number.ToString(), Value = i.Id.ToString() });
            }
            ViewBag.Gl = GL; 
            List<SelectListItem> CL = new List<SelectListItem>();
            var Clist = dbContext.Courses.ToList();
            foreach (var i in Clist)
            {
                CL.Add(new SelectListItem() { Text = i.Title, Value = i.Id.ToString() });
            }
            ViewBag.Cl = CL;
            List<SelectListItem> ClasL = new List<SelectListItem>();
            var Claslist = dbContext.Ñlassrooms.ToList();
            foreach (var i in Claslist)
            {
                ClasL.Add(new SelectListItem() { Text = i.Number.ToString(), Value = i.Id.ToString() });
            }
            ViewBag.Clasl = ClasL;
            List<string> time = new List<string> { "8:20", "9:50", "10:00", "11:35", "12:05", "13:40", "13:50", "15:25",
                "13:50", "15:25", "17:20", "18:40", "18:45", "20:05", "20:10", "21:30" };
            List<SelectListItem> Time = new List<SelectListItem>();
            for (int i = 0; i < 16; i += 2)
            {
                Time.Add(new SelectListItem() { Text = time[i] + time[i+1], Value = i.ToString() });
            }
            ViewBag.time = Time;
            List<string> weekend = new List<string> {"Ïîíåäåëüíèê", "Âòîðíèê", "Ñðåäà", "×åòâåðã", "Ïÿòíèöà", "Ñóááîòà" };
            List<SelectListItem> Weekend = new List<SelectListItem>();
            for (int j = 0; j < 6; j += 1)
            {
                Weekend.Add(new SelectListItem() { Text = weekend[j], Value = j.ToString() });
            }
            ViewBag.Weekend = Weekend;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel viewModel)
        {
            var @event = new Models.Entyties.Event
            {
                Time = viewModel.Time,
                CourseId = viewModel.CourseId,
                Weekday = viewModel.Weekday,
                GroupId = viewModel.GroupId,
                ÑlassroomId = viewModel.AudiId
            };
            await dbContext.Events.AddAsync(@event);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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
