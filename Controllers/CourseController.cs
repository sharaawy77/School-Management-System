using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class CourseController : Controller
    {
        private readonly IRepoService<Course> courservice;

        public CourseController(IRepoService<Course> courservice)
        {
            this.courservice = courservice;
        }
        public async Task<ActionResult> Index()
        {
            List<CourseVM> coursesVMs = new List<CourseVM>();
            List<Course> Results = await courservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var courseVM = new CourseVM(item);
                coursesVMs.Add(courseVM);

            }
            return View(coursesVMs);
        }
        public async Task<ActionResult> Details(int id)
        {
            if (await courservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var course = await courservice.GetValueAsync(id);
            var courseVM = new CourseVM(course);
            if (courseVM == null)
            {
                return NotFound();
            }

            return View(courseVM);
        }
        [HttpGet]

        public async Task<ActionResult> Create()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseVM model)
        {
            if (ModelState.IsValid)
            {
                await courservice.AddAsync(model.ConverVM(model));

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await courservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var Result = await courservice.GetValueAsync(id);
            if (Result == null)
            {
                return NotFound();
            }
            var courseVM = new CourseVM(Result);


            return View(courseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseVM model)
        {
            if (id != model.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await courservice.UpdateAsync(model.ConverVM(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await courservice.GetValueAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (await courservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var course = await courservice.GetValueAsync(id);
            var coursevm = new CourseVM(course);

            if (coursevm == null)
            {
                return NotFound();
            }

            return View(coursevm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await courservice.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var course = await courservice.GetValueAsync(id);

            if (course != null)
            {
                await courservice.DeleteAsync(id);
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
