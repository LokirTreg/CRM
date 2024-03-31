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
        public async Task<IActionResult> Add(int id)
        {
            Course course = new Course();
            if (id == 0)
            {
                return View(course);
            }
            else
            {
                var courseid = await dbContext.Courses.FindAsync(id);
                return View(courseid);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id, Title")] AddCourseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    var course = new Course
                    {
                        Title = viewModel.Title
                    };
                    await dbContext.Courses.AddAsync(course);
                    await dbContext.SaveChangesAsync();
                }
                if (viewModel.Id > 0)
                {
                    var course = await dbContext.Courses.FindAsync(viewModel.Id);
                    course.Title = viewModel.Title;
                    dbContext.Update(course);
                    await dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("List", "Course");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var courses = await dbContext.Courses.ToListAsync();
            return View(courses);
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
