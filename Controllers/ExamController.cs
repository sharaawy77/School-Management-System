using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;

namespace School_Management_System.Controllers
{
    public class ExamController : Controller
    {
        private readonly IRepoService<Exam> exservice;
        private readonly IRepoService<Question> qq;
        private readonly IRepoService<ExamQuestion> qservice;

        public ExamController(IRepoService<Exam> exservice,IRepoService<Question> qq,IRepoService<ExamQuestion> Qservice)
        {
            this.exservice = exservice;
            this.qq = qq;
            qservice = Qservice;
        }
        public async Task<ActionResult> Index()
        {
            List<ExamVM> TAsVMs = new List<ExamVM>();
            List<Exam> Results = await exservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var TAVM = new ExamVM(item);
                TAsVMs.Add(TAVM);

            }
            return View(TAsVMs);
        }
        public async Task<ActionResult> IndexExamQuestion()
        {
            List<ExamQuestionVM> TAsVMs = new List<ExamQuestionVM>();
            List<ExamQuestion> Results = await qservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var TAVM = new ExamQuestionVM(item);
                TAsVMs.Add(TAVM);

            }
            return View(TAsVMs);
        }
        public async Task<ActionResult> Create()
        {
            //var Exams = await sservice.GetValuesAsync();
            //SelectList StudentLST = new SelectList(Students, "StudentId", "name");
            //ViewBag.StudentId = StudentLST;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Exam model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await exservice.AddAsync(model);
                    return RedirectToAction(nameof(Index));

                }
                //var Students = await sservice.GetValuesAsync();
                //SelectList StudentLST = new SelectList(Students, "StudentId", "name");
                //ViewBag.StudentId = StudentLST;
                return View(model);

            }
            catch
            {
                //var Students = await sservice.GetValuesAsync();
                //SelectList StudentLST = new SelectList(Students, "StudentId", "name");
                //ViewBag.StudentId = StudentLST;
                return View(model);
            }
        }
        public async Task< ActionResult> CreateExamQuestions(int id)
        {
            var Questions = await qq.GetValuesAsync();
            SelectList QuestionLST = new SelectList(Questions, "QuestionId", "Body");
            ViewBag.QuestionId = QuestionLST;
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateExamQuestions(ExamQuestion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await qservice.AddAsync(model);
                    return RedirectToAction(nameof(IndexExamQuestion));

                }
                var Questions = await qq.GetValuesAsync();
                SelectList QuestionLST = new SelectList(Questions, "QuestionId", "Body");
                ViewBag.QuestionId = QuestionLST;
                ViewBag.Id = model.ExamId;
                return View(model);

            }
            catch
            {
                var Questions = await qq.GetValuesAsync();
                SelectList QuestionLST = new SelectList(Questions, "QuestionId", "Body");
                ViewBag.QuestionId = QuestionLST;
                ViewBag.Id = model.ExamId;
                return View(model);
            }
        }
    }
}
