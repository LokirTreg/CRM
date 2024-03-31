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
    public class GroupsController : Controller
    {
        private readonly AppDbContext dbContext;
        public GroupsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            Models.Entyties.Group group = new Models.Entyties.Group();
            if (id == 0)
            {
                return View(group);
            }
            else
            {
                var groupid = await dbContext.Groups.FindAsync(id);
                return View(groupid);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id, Number")] AddGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    var group = new Models.Entyties.Group
                    {
                        Number = viewModel.Number
                    };
                    await dbContext.Groups.AddAsync(group);
                    await dbContext.SaveChangesAsync();
                }
                if (viewModel.Id > 0)
                {
                    var group = await dbContext.Groups.FindAsync(viewModel.Id);
                    group.Number = viewModel.Number;
                    dbContext.Update(group);
                    await dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("List", "Groups");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var groups = await dbContext.Groups.ToListAsync();
            return View(groups);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var group = await dbContext.Groups
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Groups.Remove(group);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Groups");
        }
    }
}
