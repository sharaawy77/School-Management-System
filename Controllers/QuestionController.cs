using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IRepoService<Question> qService;

        public QuestionController(IRepoService<Question> qService)
        {
            this.qService = qService;
        }
        // GET: QuestionController
        public async Task<ActionResult> Index()
        {
            List<QuestionVM> QAsVMs = new List<QuestionVM>();
            List<Question> Results = await qService.GetValuesAsync();
            foreach (var item in Results)
            {
                var QAVM = new QuestionVM(item);
                QAsVMs.Add(QAVM);

            }
            return View(QAsVMs);
        }

        // GET: QuestionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionController/Create
        public async Task<ActionResult> Create()
        {
            //var Questions = await qService.GetValuesAsync();
            //SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
            //ViewBag.TeacherId = TeacherLST;
            return View();
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Question model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await qService.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                //var Teachers = await teacSErvice.GetValuesAsync();
                //SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
                //ViewBag.TeacherId = TeacherLST;
                return View(model);

            }
            catch
            {
                //var Teachers = await teacSErvice.GetValuesAsync();
                //SelectList TeacherLST = new SelectList(Teachers, "TeacherId", "Name");
                //ViewBag.TeacherId = TeacherLST;
                return View(model);
            }
        }

        // GET: QuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
