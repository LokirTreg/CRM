using CRM.WEB.Data;
using CRM.WEB.Models.Entyties;
using CRM.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRM.WEB.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly AppDbContext dbContext;
        public ClassroomController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddСlassroomViewModel viewModel)
        {
            var сlassroom = new Models.Entyties.Сlassroom
            {
                Number = viewModel.Number,
            };
            await dbContext.Сlassrooms.AddAsync(сlassroom);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Classroom");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var сlassrooms = await dbContext.Сlassrooms.ToListAsync();
            return View(сlassrooms);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var сlassroom = await dbContext.Сlassrooms.FindAsync(id);
            return View(сlassroom);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Entyties.Сlassroom viewModel)
        {

            var сlassroom = await dbContext.Сlassrooms.FindAsync(viewModel.Id);
            if (сlassroom is not null)
            {
                сlassroom.Number = viewModel.Number;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Classroom");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Models.Entyties.Сlassroom viewModel)
        {
            var сlassroom = await dbContext.Сlassrooms
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (сlassroom is not null)
            {
                dbContext.Сlassrooms.Remove(сlassroom);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Classroom");
        }
    }
}
