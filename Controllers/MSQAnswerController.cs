using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class MSQAnswerController : Controller
    {
        private readonly IRepoService<MSQAnswer> msqservice;
        private readonly IRepoService<Question> quesservice;

        public MSQAnswerController(IRepoService<MSQAnswer> msqservice,IRepoService<Question> quesservice)
        {
            this.msqservice = msqservice;
            this.quesservice = quesservice;
        }
        // GET: MSQAnswerController
        public async Task<ActionResult> Index()
        {
            List<MSQAnswerVM> QAsVMs = new List<MSQAnswerVM>();
            List<MSQAnswer> Results = await msqservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var QAVM = new MSQAnswerVM(item);
                QAsVMs.Add(QAVM);

            }
            return View(QAsVMs);
        }

        // GET: MSQAnswerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MSQAnswerController/Create
        public async Task< ActionResult> Create()
        {
            var Questions = await quesservice.GetValuesAsync();
            var MsqQuestions=Questions.Where(q=>q.MsqRAns!=null);
            SelectList MSQrLST = new SelectList(MsqQuestions, "QuestionId", "Body");
            ViewBag.QuestionId = MSQrLST;
            return View();
        }

        // POST: MSQAnswerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MSQAnswer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await msqservice.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                var Questions = await quesservice.GetValuesAsync();
                var MsqQuestions = Questions.Where(q => q.MsqRAns != null);
                SelectList MSQrLST = new SelectList(MsqQuestions, "QuestionId", "Body");
                ViewBag.QuestionId = MSQrLST;
                return View(model);

            }
            catch
            {
                var Questions = await quesservice.GetValuesAsync();
                var MsqQuestions = Questions.Where(q => q.MsqRAns != null);
                SelectList MSQrLST = new SelectList(MsqQuestions, "QuestionId", "Body");
                ViewBag.QuestionId = MSQrLST;
                return View(model);
            }
        }

        // GET: MSQAnswerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MSQAnswerController/Edit/5
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

        // GET: MSQAnswerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MSQAnswerController/Delete/5
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
