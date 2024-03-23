using CRM.WEB.Data;
using CRM.WEB.Models.Entyties;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM.WEB.Controllers
{
    public class TeachersController : Controller
    {
        private readonly AppDbContext dbContext;
        public TeachersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> CL = new List<SelectListItem>();
            var Clist = dbContext.Courses.ToList();
            foreach (var i in Clist)
            {
                CL.Add(new SelectListItem() { Text = i.Title, Value = i.Id.ToString() });
            }
            ViewBag.Cl = CL;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTeacherViewModel viewModel)
        {
            var teacher = new Teacher
            {
                Name = viewModel.Name,
            };
            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            var teachers = await dbContext.Teachers.ToListAsync();
            return View("List", teachers);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = from st in dbContext.Students
                           join gr in dbContext.Groups on st.GroupId equals gr.Id
                           select new StudentDetailView
                           {
                               student = st,
                               gro = gr
                           };
            var teachers = from te in dbContext.Teachers
                           join co in dbContext.Courses on te.CourseId equals co.Id
                           select new TeacherDetailView
                           {
                               teacher=te,
                               course=co
                           };
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await dbContext.Teachers.FindAsync(id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher viewModel)
        {
            var teacher = await dbContext.Teachers.FindAsync(viewModel.Id);
            if (teacher is not null)
            {
                teacher.Name = viewModel.Name;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Teachers");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Teacher viewModel)
        {
            var teacher = await dbContext.Teachers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (teacher is not null)
            {
                dbContext.Teachers.Remove(teacher);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Teachers");
        }
    }
}
