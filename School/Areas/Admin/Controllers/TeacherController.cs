using System;
using System.Collections.Generic;
using System.Linq;
using School.Models;
using School.ViewModel;
using System.Web.Mvc;
using School.DAL;

namespace School.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        TeacherDAL _teacherDAL = new TeacherDAL();
        SubjectsDAL _subjectDAL = new SubjectsDAL();
        StudentsDAL _studentDAL = new StudentsDAL();
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
        public PartialViewResult SubjectsDetails()
        {
            return PartialView(_subjectDAL.GetAll());
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
        [HttpGet]
        public PartialViewResult AddSubjectForm()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult AddSubjectForm(SubjectsVM subjectsVM)
        {
            string message;

            // map subjectVM object to subject object 
            var subject = new Subject()
            {
                Name = subjectsVM.Name
            };

            return Json(new { done = _subjectDAL.Add(subject, out message),
                    message,
                formName = $"{nameof(Subject)}"
            },
                JsonRequestBehavior.AllowGet);
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
                SubjectFK = stdSubVM.StudentFK
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