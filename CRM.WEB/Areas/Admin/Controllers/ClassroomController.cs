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
        public async Task<IActionResult> Add(int id)
        {
            Audi audi = new Audi();
            if (id == 0)
            {
                return View(audi);
            }
            else
            {
                var audiid = await dbContext.Audi.FindAsync(id);
                return View(audiid);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id, Number")] AddAudiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    var audi = new Audi
                    {
                        Number = viewModel.Number
                    };
                    await dbContext.Audi.AddAsync(audi);
                    await dbContext.SaveChangesAsync();
                }
                if (viewModel.Id > 0)
                {
                    var audi = await dbContext.Audi.FindAsync(viewModel.Id);
                    audi.Number = viewModel.Number;
                    dbContext.Update(audi);
                    await dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("List", "Classroom");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Audi = await dbContext.Audi.ToListAsync();
            return View(Audi);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Audi = await dbContext.Audi.FindAsync(id);
            return View(Audi);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Entyties.Audi viewModel)
        {

            var Audi = await dbContext.Audi.FindAsync(viewModel.Id);
            if (Audi is not null)
            {
                Audi.Number = viewModel.Number;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Classroom");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Models.Entyties.Audi viewModel)
        {
            var Audi = await dbContext.Audi
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (Audi is not null)
            {
                dbContext.Audi.Remove(Audi);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Classroom");
        }
    }
}
