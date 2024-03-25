using CRM.WEB.Data;
using CRM.WEB.Models;
using CRM.WEB.Models.Entyties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRM.WEB.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext dbContext;
        public StudentsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> GL = new List<SelectListItem>();
            var Glist = dbContext.Groups.ToList();
            foreach (var i in Glist)
            {
                GL.Add(new SelectListItem() { Text = i.Number.ToString(), Value = i.Id.ToString() });
            }
            ViewBag.Gl = GL;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                GroupId = viewModel.GroupId
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Students");
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
            return View(students);
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
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
