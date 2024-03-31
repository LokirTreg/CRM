using CRM.WEB.Data;
using CRM.WEB.Models;
using CRM.WEB.Models.Entyties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CRM.WEB.Controllers
{
    public class HouseController : Controller
    {
        private readonly AppDbContext dbContext;

        public HouseController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var events = from ev in dbContext.Events
                           join gr in dbContext.Groups on ev.GroupId equals gr.Id
                           join co in dbContext.Courses on ev.CourseId equals co.Id
                           join cl in dbContext.Audi on ev.AudiId equals cl.Id
                           join te in dbContext.Teachers on ev.TeacherId equals te.Id
                           select new EventDetailView
                           {
                               eevent = ev,
                               gro = gr,
                               course = co,
                               teacher = te,
                               audi = cl
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
            var Claslist = dbContext.Audi.ToList();
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
            List<string> weekend = new List<string> {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            List<SelectListItem> Weekend = new List<SelectListItem>();
            for (int j = 0; j < 6; j += 1)
            {
                Weekend.Add(new SelectListItem() { Text = weekend[j], Value = j.ToString() });
            }
            var eevent1 = await dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == 5);
            ViewBag.Weekend = Weekend;
            Event eevent = new Event();
            if (id == 0)
            {
                return View(eevent);
            }
            else
            {
                var eeventid =  dbContext.Events.Find(id);
                return View(eeventid);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id, Time, CourseId, GroupId, Weekday, TeacherId, AudiId")] AddEventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    var eevent = new Models.Entyties.Event
                    {
                        Time = viewModel.Time,
                        CourseId = viewModel.CourseId,
                        Weekday = viewModel.Weekday,
                        GroupId = viewModel.GroupId,
                        TeacherId = viewModel.TeacherId,
                        AudiId = viewModel.AudiId
                    };
                    await dbContext.Events.AddAsync(eevent);
                    await dbContext.SaveChangesAsync();
                }
                if (viewModel.Id > 0)
                {
                    var eevent = await dbContext.Events.FindAsync(viewModel.Id);
                    eevent.Time = viewModel.Time;
                    eevent.CourseId = viewModel.CourseId;
                    eevent.Weekday = viewModel.Weekday;
                    eevent.GroupId = viewModel.GroupId;
                    eevent.TeacherId = viewModel.TeacherId;
                    eevent.AudiId = viewModel.AudiId;
                    dbContext.Update(eevent);
                    await dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index", "House");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var eevents = await dbContext.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Events.Remove(eevents);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "House");
        }
    }
}
