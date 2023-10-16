using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class TeacherAttendanceController : Controller
    {
        private readonly IRepoService<TeacherAttendance> tAService;
        private readonly IRepoService<Teacher> teacSErvice;

        public TeacherAttendanceController(IRepoService<TeacherAttendance> TAService, IRepoService<Teacher> teacSErvice)
        {
            tAService = TAService;
            this.teacSErvice = teacSErvice;
        }
        // GET: TeacherAttendanceController
        public async Task< ActionResult> Index()
        {
            List<TeacherAttendanceVM> TAsVMs = new List<TeacherAttendanceVM>();
            List<TeacherAttendance> Results = await tAService.GetValuesAsync();
            foreach (var item in Results)
            {
                var TAVM = new TeacherAttendanceVM(item);
                TAsVMs.Add(TAVM);

            }
            return View(TAsVMs);
        }

        // GET: TeacherAttendanceController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (await tAService.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var TA = await tAService.GetValueAsync(id);
            var TAvm = new TeacherAttendanceVM(TA);
            if (TAvm == null)
            {
                return NotFound();
            }

            return View(TAvm);
        }

        // GET: TeacherAttendanceController/Create
        public async Task< ActionResult> Create()
        {
            var Teachers = await teacSErvice.GetValuesAsync();
            SelectList TeacherLST = new SelectList(Teachers, "TeacherId","Name");
            ViewBag.TeacherId = TeacherLST;
            return View();
        }

        // POST: TeacherAttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherAttendance model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await tAService.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                var Teachers = await teacSErvice.GetValuesAsync();
                SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
                ViewBag.TeacherId = TeacherLST;
                return View(model);

            }
            catch
            {
                var Teachers = await teacSErvice.GetValuesAsync();
                SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
                ViewBag.TeacherId = TeacherLST;
                return View(model);
            }
        }

        // GET: TeacherAttendanceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var Teachers = await teacSErvice.GetValuesAsync();
            SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
            ViewBag.TeacherId = TeacherLST;
            return View();
        }

        // POST: TeacherAttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TeacherAttendance model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await tAService.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                var Teachers = await teacSErvice.GetValuesAsync();
                SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
                ViewBag.TeacherId = TeacherLST;
                return View(model);

            }
            catch
            {
                var Teachers = await teacSErvice.GetValuesAsync();
                SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
                ViewBag.TeacherId = TeacherLST;
                return View(model);
            }
        }

        // GET: TeacherAttendanceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (await tAService.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var TA = await tAService.GetValueAsync(id);
            var TAvm = new TeacherAttendanceVM(TA);

            if (TAvm == null)
            {
                return NotFound();
            }

            return View(TAvm);
        }

        // POST: TeacherAttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            if (await tAService.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var Ta = await tAService.GetValueAsync(id);

            if (Ta != null)
            {
                await tAService.DeleteAsync(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
    
}
