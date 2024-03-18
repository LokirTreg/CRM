using CRM.WEB.Data;
using CRM.WEB.Models.Entyties;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace CRM.WEB.Controllers
{
    public class GroupsController : Controller
    {
        private readonly AppDbContext dbContext;
        public GroupsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddGroupModelView viewModel)
        {
            var group = new Models.Entyties.Group
            {
                Number = viewModel.Number,
                Group_Students = viewModel.Group_Students
            };
            await dbContext.Groups.AddAsync(group);
            await dbContext.SaveChangesAsync();
            var groups = await dbContext.Groups.ToListAsync();
            return View("List", groups);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var groups = await dbContext.Groups.ToListAsync();
            return View(groups);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var group = await dbContext.Groups.FindAsync(id);
            return View(group);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Entyties.Group viewModel)
        {
            var group = await dbContext.Groups.FindAsync(viewModel.Id);
            if (group is not null)
            {
                group.Number = viewModel.Number;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Groups");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Models.Entyties.Group viewModel)
        {
            var group = await dbContext.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (group is not null)
            {
                dbContext.Groups.Remove(group);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Groups");
        }
    }
}
