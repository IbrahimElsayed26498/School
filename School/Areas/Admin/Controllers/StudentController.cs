using School.DAL;
using School.Models;
using School.ViewModel;
using System.Web.Mvc;

namespace School.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        StudentsDAL _studentDAL = new StudentsDAL();
        // GET: Admin/Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddStudentForm()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult AddStudentForm(StudentsVM studentVM)
        {
            string message;

            // map subjectVM object to subject object 
            var student = new Student()
            {
                Name = studentVM.Name,
                TeacherFK = studentVM.TeacherFK
            };

            return Json(new
            {
                done = _studentDAL.Add(student, out message),
                message,
                formName = $"{nameof(Student)}"
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}