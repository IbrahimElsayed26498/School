using School.DAL;
using School.Models;
using School.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace School.Areas.Admin.Controllers
{
    public class StudnetsSubjectsController : Controller
    {
        StudentSubjectDAL _stdSubDAL = new StudentSubjectDAL();
        // GET: Admin/StudnetsSubjects
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddStudentSubjectForm()
        {
            ViewBag.FormName = $"{nameof(AddStudentSubjectForm)}";
            return PartialView();
        }
        [HttpPost]
        public JsonResult AddStudentSubjectForm(StudentSubjectVM stdSubVM)
        {
            string message;

            // map subjectVM object to subject object 
            var stdSub = new StudentSubject()
            {
                StudentFK = stdSubVM.StudentFK,
                SubjectFK = stdSubVM.SubjectFK
            };

            return Json(new
            {
                done = _stdSubDAL.Add(stdSub, out message),
                message,
                formName = $"{nameof(StudentSubject)}"
            },
                JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult Edit(int stdID, int subID)
        {
            ViewBag.FormName = $"{nameof(PostEdit)}";
            var obj = _stdSubDAL.GetAll().
                Where(item => item.StudentFK == stdID && item.SubjectFK == subID).FirstOrDefault();

            var stdSubVM = new StudentSubjectVM()
            {
                ID = obj.ID,
                StudentFK = obj.StudentFK,
                SubjectFK = obj.SubjectFK
            };
            return PartialView($"{nameof(AddStudentSubjectForm)}", stdSubVM);
        }
        [HttpPost]
        public JsonResult PostEdit(StudentSubjectVM stdSubVM)
        {
            string message;
            var stdSub = new StudentSubject()
            {
                ID = stdSubVM.ID,
                StudentFK = stdSubVM.StudentFK,
                SubjectFK = stdSubVM.SubjectFK,
            };
            return Json(new
            {
                done = _stdSubDAL.Edit(stdSub, out message),
                message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}