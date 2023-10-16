using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class TORFAnswerController : Controller
    {
        private readonly IRepoService<T_OR_F_Answer> tservice;
        private readonly IRepoService<Question> quesservice;

        public TORFAnswerController(IRepoService<T_OR_F_Answer> tservice,IRepoService<Question> quesservice)
        {
            this.tservice = tservice;
            this.quesservice = quesservice;
        }
        // GET: TORFAnswerController
        public async Task<ActionResult> Index()
        {
            List<TORFAnswerVM> QAsVMs = new List<TORFAnswerVM>();
            List<T_OR_F_Answer> Results = await tservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var QAVM = new TORFAnswerVM(item);
                QAsVMs.Add(QAVM);

            }
            return View(QAsVMs);
        }

        // GET: TORFAnswerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TORFAnswerController/Create
        public async Task<ActionResult> Create()
        {
            var Questions = await quesservice.GetValuesAsync();
            var MsqQuestions = Questions.Where(q => q.MsqRAns == null);
            SelectList MSQrLST = new SelectList(MsqQuestions, "QuestionId", "Body");
            ViewBag.QuestionId = MSQrLST;
            return View();
        }

        // POST: TORFAnswerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(T_OR_F_Answer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await tservice.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                var Questions = await quesservice.GetValuesAsync();
                var MsqQuestions = Questions.Where(q => q.MsqRAns == null);
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

        // GET: TORFAnswerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TORFAnswerController/Edit/5
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

        // GET: TORFAnswerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TORFAnswerController/Delete/5
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
