﻿using School.DAL;
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
            ViewBag.FormName = $"{nameof(AddStudentForm)}";
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
        public PartialViewResult Edit(int id)
        {
            ViewBag.FormName = $"{nameof(Edit)}";
            var obj = _studentDAL.GetOne(id);
            var studnetVM = new StudentsVM()
            {
                ID = obj.ID,
                Name = obj.Name,
                TeacherFK = obj.TeacherFK
            };
            return PartialView($"{nameof(AddStudentForm)}", studnetVM);
        }
        [HttpPost]
        public JsonResult Edit(StudentsVM studentsVM)
        {
            string message;
            var student = new Student()
            {
                ID = studentsVM.ID,
                Name = studentsVM.Name,
                TeacherFK = studentsVM.TeacherFK,
            };
            return Json(new
            {
                done = _studentDAL.Edit(student, out message),
                message
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            string message;
            return Json(new
            {
                done = _studentDAL.Delete(id, out message),
                message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}