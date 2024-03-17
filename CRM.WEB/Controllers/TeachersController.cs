using CRM.WEB.Data;
using CRM.WEB.Models.Entyties;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTeacherViewModel viewModel)
        {
            var teacher = new Teacher
            {
                FIO = viewModel.FIO,
            };
            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();
            var teachers = await dbContext.Teachers.ToListAsync();
            return View("List", teachers);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var teachers = await dbContext.Teachers.ToListAsync();
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
                teacher.FIO = viewModel.FIO;
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
