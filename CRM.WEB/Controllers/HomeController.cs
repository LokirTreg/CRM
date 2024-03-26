using CRM.WEB.Data;
using CRM.WEB.Models;
using CRM.WEB.Models.Entyties;
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
                           join cl in dbContext.Ñlassrooms on ev.ÑlassroomId equals cl.Id
                           join te in dbContext.Teachers on ev.TeacherId equals te.Id
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
        public async Task<IActionResult> Add(int id)
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

            List<SelectListItem> TeL = new List<SelectListItem>();
            var Telist = dbContext.Teachers.ToList();
            foreach (var i in Telist)
            {
                TeL.Add(new SelectListItem() { Text = i.Name, Value = i.Id.ToString() });
            }
            ViewBag.Tel = TeL;
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
            if (id == 0)
            {
                return View();
            }
            else
            {
                var eevent = await dbContext.Events
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                return View(eevent);
            }
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
                TeacherId = viewModel.TeacherId,
                ÑlassroomId = viewModel.AudiId
            };
            await dbContext.Events.AddAsync(@event);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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

            List<SelectListItem> TeL = new List<SelectListItem>();
            var Telist = dbContext.Teachers.ToList();
            foreach (var i in Telist)
            {
                TeL.Add(new SelectListItem() { Text = i.Name, Value = i.Id.ToString() });
            }
            ViewBag.Tel = TeL;
            List<string> time = new List<string> { "8:20", "9:50", "10:00", "11:35", "12:05", "13:40", "13:50", "15:25",
                "13:50", "15:25", "17:20", "18:40", "18:45", "20:05", "20:10", "21:30" };
            List<SelectListItem> Time = new List<SelectListItem>();
            for (int i = 0; i < 16; i += 2)
            {
                Time.Add(new SelectListItem() { Text = time[i] + " - " + time[i + 1], Value = i.ToString() });
            }
            ViewBag.time = Time;
            List<string> weekend = new List<string> { "Ïîíåäåëüíèê", "Âòîðíèê", "Ñðåäà", "×åòâåðã", "Ïÿòíèöà", "Ñóááîòà" };
            List<SelectListItem> Weekend = new List<SelectListItem>();
            for (int j = 0; j < 6; j += 1)
            {
                Weekend.Add(new SelectListItem() { Text = weekend[j], Value = j.ToString() });
            }
            ViewBag.Weekend = Weekend;
            var eevent = await dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return View(eevent);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Event viewModel)
        {
            var eevent = await dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == 4);
            if (eevent is not null)
            {
                eevent.Weekday = viewModel.Weekday;
                eevent.Time = viewModel.Time;
                eevent.CourseId = viewModel.CourseId;
                eevent.TeacherId = viewModel.TeacherId;
                eevent.ÑlassroomId = viewModel.ÑlassroomId;
                eevent.GroupId = viewModel.GroupId;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Events.Remove(student);
                await dbContext.SaveChangesAsync();
            }
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
