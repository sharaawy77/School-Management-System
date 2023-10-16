using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepoService<Student> studservice;
        private readonly IRepoService<Teacher> teacSErvice;

        public StudentController(IRepoService<Student> studservice,IRepoService<Teacher>  teacSErvice)
        {
            this.studservice = studservice;
            this.teacSErvice = teacSErvice;
        }
        public async Task< IActionResult> Index()
        {
            List<StudentVM> StudsVMs = new List<StudentVM>();
            List<Student> Results = await studservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var studVM = new StudentVM(item);
                StudsVMs.Add(studVM);

            }
            return View(StudsVMs);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (await studservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var std = await studservice.GetValueAsync(id);
            var stdvm = new StudentVM(std);
            if (std == null)
            {
                return NotFound();
            }

            return View(stdvm);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentVM model)
        {
            if (ModelState.IsValid)
            {
                await studservice.AddAsync(model.ConvertVM(model));

                return RedirectToAction(nameof(Index));
            }
           
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await studservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var Result = await studservice.GetValueAsync(id);
            if (Result == null)
            {
                return NotFound();
            }
            var stdVM = new StudentVM(Result);
            

            return View(stdVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,StudentVM model)
        {
            if (id != model.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await studservice.UpdateAsync( model.ConvertVM(model));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await studservice.GetValueAsync(id) == null)
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
            if (await studservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var std = await studservice.GetValueAsync(id);
            var stdvm = new StudentVM(std);

            if (std == null)
            {
                return NotFound();
            }

            return View(stdvm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await studservice.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var std = await studservice.GetValueAsync(id);

            if (std != null)
            {
                await studservice.DeleteAsync(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
