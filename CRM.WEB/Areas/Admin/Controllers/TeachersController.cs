using CRM.WEB.Data;
using CRM.WEB.Models.Entyties;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<IActionResult> Add(int id)
        {
            Teacher teacher = new Teacher();
            if (id == 0)
            {
                return View(teacher);
            }
            else
            {
                var teacherid = await dbContext.Teachers.FindAsync(id);
                return View(teacherid);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add([Bind("Id, Name")] AddTeacherViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    var teacher = new Teacher
                    {
                        Name = viewModel.Name
                    };
                    await dbContext.Teachers.AddAsync(teacher);
                    await dbContext.SaveChangesAsync();
                }
                if (viewModel.Id > 0)
                {
                    var teacher = await dbContext.Teachers.FindAsync(viewModel.Id);
                    teacher.Name = viewModel.Name;
                    dbContext.Update(teacher);
                    await dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("List", "Teachers");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var teachers = from te in dbContext.Teachers
                           select new TeacherDetailView
                           {
                               teacher=te
                           };
            return View(teachers);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var teacher = await dbContext.Teachers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Teachers.Remove(teacher);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Teachers");
        }
    }
}
