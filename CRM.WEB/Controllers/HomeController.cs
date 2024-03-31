using Microsoft.AspNetCore.Http;
using CRM.WEB.Data;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Schedule()
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
        public async Task<IActionResult> StudentList()
        {
            var students = from st in dbContext.Students
                           join gr in dbContext.Groups on st.GroupId equals gr.Id
                           select new StudentDetailView
                           {
                               student = st,
                               gro = gr
                           };
            return View(students);
        }
        public async Task<IActionResult> TeacherList()
        {
            var teachers = from te in dbContext.Teachers
                           select new TeacherDetailView
                           {
                               teacher = te
                           };
            return View(teachers);
        }
        public async Task<IActionResult> GroupList()
        {
            var groups = await dbContext.Groups.ToListAsync();
            return View(groups);
        }
        public async Task<IActionResult> CourseList()
        {
            var courses = await dbContext.Courses.ToListAsync();
            return View(courses);
        }
        public async Task<IActionResult> ClassromList()
        {
            var Audi = await dbContext.Audi.ToListAsync();
            return View(Audi);
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
