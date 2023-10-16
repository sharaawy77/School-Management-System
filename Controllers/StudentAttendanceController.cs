using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class StudentAttendanceController : Controller
    {
        private readonly IRepoService<StudentsAttendance> sTservice;
        private readonly IRepoService<Student> sservice;

        public StudentAttendanceController(IRepoService<StudentsAttendance> STservice,IRepoService<Student> Sservice)
        {
            sTservice = STservice;
            sservice = Sservice;
        }
        public async Task<ActionResult> Index()
        {
            List<StudentAttendanceVM> TAsVMs = new List<StudentAttendanceVM>();
            List<StudentsAttendance> Results = await sTservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var TAVM = new StudentAttendanceVM(item);
                TAsVMs.Add(TAVM);

            }
            return View(TAsVMs);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (await sTservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var TA = await sTservice.GetValueAsync(id);
            var TAvm = new StudentAttendanceVM(TA);
            if (TAvm == null)
            {
                return NotFound();
            }

            return View(TAvm);
        }
        public async Task<ActionResult> Create()
        {
            var Students = await sservice.GetValuesAsync();
            SelectList StudentLST = new SelectList(Students, "StudentId", "name");
            ViewBag.StudentId = StudentLST;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentsAttendance model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await sTservice.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                var Students = await sservice.GetValuesAsync();
                SelectList StudentLST = new SelectList(Students, "StudentId", "name");
                ViewBag.StudentId = StudentLST;
                return View(model);

            }
            catch
            {
                var Students = await sservice.GetValuesAsync();
                SelectList StudentLST = new SelectList(Students, "StudentId", "name");
                ViewBag.StudentId = StudentLST;
                return View(model);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            var Students = await sservice.GetValuesAsync();
            SelectList StudentLST = new SelectList(Students, "StudentId", "name");
            ViewBag.StudentId = StudentLST;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentsAttendance model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await sTservice.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                var Students = await sservice.GetValuesAsync();
                SelectList StudentLST = new SelectList(Students, "StudentId", "name");
                ViewBag.TeacherId = StudentLST;
                return View(model);

            }
            catch
            {
                var Students = await sservice.GetValuesAsync();
                SelectList StudentLST = new SelectList(Students, "StudentId", "name");
                ViewBag.TeacherId = StudentLST;
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (await sTservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var TA = await sTservice.GetValueAsync(id);
            var TAvm = new StudentAttendanceVM(TA);

            if (TAvm == null)
            {
                return NotFound();
            }

            return View(TAvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            if (await sTservice.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var Ta = await sTservice.GetValueAsync(id);

            if (Ta != null)
            {
                await sTservice.DeleteAsync(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
