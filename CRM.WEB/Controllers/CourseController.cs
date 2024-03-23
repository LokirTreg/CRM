using CRM.WEB.Data;
using CRM.WEB.Models.Entyties;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM.WEB.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext dbContext;
        public CourseController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel viewModel)
        {
            var course = new Models.Entyties.Course
            {
                Title = viewModel.Title,
            };
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Course");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var courses = await dbContext.Courses.ToListAsync();
            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await dbContext.Courses.FindAsync(id);
            /*
            List<SelectListItem> listTeachers = new List<SelectListItem>();
            var sts = await dbContext.Teachers.ToListAsync();
            foreach (var item in sts)
            {
                listTeachers.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.ListTeachers = listTeachers;
            */
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Entyties.Course viewModel)
        {

            var course = await dbContext.Courses.FindAsync(viewModel.Id);
            if (course is not null)
            {
                course.Title = viewModel.Title;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Course");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Models.Entyties.Course viewModel)
        {
            var course = await dbContext.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (course is not null)
            {
                dbContext.Courses.Remove(course);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Course");
        }
    }
}
