
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Management_System.FiileService;
using School_Management_System.Models;
using School_Management_System.Services;
using School_Management_System.ViewModels;


namespace School_Management_System.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IRepoService<Teacher> tecservice;
        private readonly IRepoService<Course> courseservice;
        private readonly IFileService service;

        public TeacherController(IRepoService<Teacher> tecservice,IRepoService<Course> courseservice,IFileService service )
        {
            this.tecservice = tecservice;
            this.courseservice = courseservice;
            this.service = service;
        }
        // GET: TeacherController
        public async Task< ActionResult> Index()
        {
            List<TeacherVM> teacsVMs = new List<TeacherVM>();
            List<Teacher> Results = await tecservice.GetValuesAsync();
            foreach (var item in Results)
            {
                var teacVM = new TeacherVM(item);
                teacsVMs.Add(teacVM);

            }
            return View(teacsVMs);
        }

        // GET: TeacherController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            if (await tecservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var teac = await tecservice.GetValueAsync(id);
            var teacVM = new TeacherVM(teac);
            if (teac == null)
            {
                return NotFound();
            }

            return View(teacVM);
        }

        // GET: TeacherController/Create
        [HttpGet]

        public async Task< ActionResult> Create()
        {
            //var coursees = await  courseservice.GetValuesAsync();
            //SelectList courses = new SelectList(coursees, "CourseId", "Name");
            ViewBag.CourseId = await courseservice.GetValuesAsync();
            
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(TeacherVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.ProfilePic!=null)
                {
                    var result = service.SaveImage(model.ProfilePic);
                    if (result.Item1==1)
                    {
                        model.PicUrl = result.Item2;
                    }

                    

                }
                var teac = model.ConvertVM(model);
                await tecservice.AddAsync(teac);
                return RedirectToAction(nameof(Index));

            }
            //var coursees = await courseservice.GetValuesAsync();
            //SelectList courses = new SelectList(coursees, "CourseId", "Name");
            ViewBag.CourseId = await courseservice.GetValuesAsync();

            return View(model);

        }

        // GET: TeacherController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (await tecservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var Result = await tecservice.GetValueAsync(id);
            if (Result == null)
            {
                return NotFound();
            }
            var teacVM = new TeacherVM(Result);


            return View(teacVM);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task< ActionResult> Edit(TeacherVM model)
        {
            if (ModelState.IsValid)
            {
                var oldpicName = tecservice.GetValueAsync(model.TeacherId).Result.ProfilePic;
                if (model.ProfilePic != null)
                {
                    var res = service.DeleteImage(oldpicName);
                    if (res)
                    {
                        var Result = service.SaveImage(model.ProfilePic);
                        if (Result.Item1 == 1)
                        {
                            model.PicUrl = Result.Item2;

                        }



                    }
                   
                }
                var teac = model.ConvertVM(model);
                await tecservice.UpdateAsync(teac);

                return RedirectToAction(nameof(Index));

            }
            return View(model);

        }

        // GET: TeacherController/Delete/5
        [HttpGet]
        public async  Task<ActionResult> Delete(int id)
        {
            if (await tecservice.GetValuesAsync() == null)
            {
                return NotFound();
            }

            var teac = await tecservice.GetValueAsync(id);
            var teacVm = new TeacherVM(teac);

            if (teac == null)
            {
                return NotFound();
            }

            return View(teacVm);
        }

        // POST: TeacherController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> DeleteConfirmed(int id)
        {
            if (await tecservice.GetValuesAsync() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var teac = await tecservice.GetValueAsync(id);

            if (teac != null)
            {
                await tecservice.DeleteAsync(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
