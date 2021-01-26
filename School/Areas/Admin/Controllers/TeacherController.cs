using System.Collections.Generic;
using School.Models;
using School.ViewModel;
using System.Web.Mvc;
using School.DAL;

namespace School.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        TeacherDAL _teacherDAL = new TeacherDAL();
        StudentSubjectDAL _stdSubDAL = new StudentSubjectDAL();

        // GET: Admin/Teacher
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Details()
        {
            var tss = new List<TeacherStudnetsSubjects>();
            var teachers = _teacherDAL.GetAll();
            foreach (var item in teachers)
            {
                tss.Add(new TeacherStudnetsSubjects(item));
            }
            return PartialView(tss);
        }
        
        [HttpGet]
        public PartialViewResult AddTeacherForm()
        {
            return PartialView();
        }

        // todo: post the teacher form to the database
        [HttpPost]
        public JsonResult AddTeacherForm(TeachersVM teacherVM)
        {
            string message;

            // map teacher view model object to teacher vm
            Teacher teacher = new Teacher()
            {
                Name = teacherVM.Name
            };
            
            return Json(new { 
                done = _teacherDAL.Add(teacher, out message),
                message,
                formName = $"{nameof(Teacher)}"
                },
                JsonRequestBehavior.AllowGet);
        }
        
        
    }
}