using School.DAL;
using School.Models;
using School.ViewModel;
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
    }
}