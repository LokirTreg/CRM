using CRM.WEB.Data;
using CRM.WEB.Models;
using CRM.WEB.Models.Entyties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> Add(int id)
        {
            List<SelectListItem> GL = new List<SelectListItem>();
            var Glist = dbContext.Groups.ToList();
            foreach (var i in Glist)
            {
                GL.Add(new SelectListItem() { Text = i.Number.ToString(), Value = i.Id.ToString() });
            }
            ViewBag.Gl = GL;
            Student student = new Student();
            if (id == 0)
            {
                return View(student);
            }
            else
            {
                var studentid = await dbContext.Students.FindAsync(id);
                return View(studentid);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id, Name, Email, GroupId")] AddStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    var student = new Student
                    {
                        Name = viewModel.Name,
                        Email = viewModel.Email,
                        GroupId = viewModel.GroupId
                    };
                    await dbContext.Students.AddAsync(student);
                    await dbContext.SaveChangesAsync();
                }
                if (viewModel.Id > 0)
                {
                    var student = await dbContext.Students.FindAsync(viewModel.Id);
                    student.Name = viewModel.Name;
                    student.Email = viewModel.Email;
                    student.GroupId = viewModel.GroupId;
                    dbContext.Update(student);
                    await dbContext.SaveChangesAsync();
                }
            }
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
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var student = await dbContext.Students
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
