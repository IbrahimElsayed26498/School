using School.DAL;
using School.Models;
using School.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace School.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        SubjectsDAL _subjectDAL = new SubjectsDAL();
        StudentSubjectDAL _stdSubDAL = new StudentSubjectDAL();

        // GET: Admin/Subject
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SubjectsDetails()
        {
            return PartialView(_subjectDAL.GetAll());
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

            return Json(new
            {
                done = _subjectDAL.Add(subject, out message),
                message,
                formName = $"{nameof(Subject)}"
            },
                JsonRequestBehavior.AllowGet);
        }
        // this Action returns the unselected subjects to the studnet.
        // if a student selected a subject, so he can't select it again.
        [HttpGet]
        public JsonResult GetSubjects(int id)
        {
            var stdSubs = _stdSubDAL.GetAll().Where(z => z.StudentFK == id).
                Select(z => z.SubjectFK).ToList(); // get the subjects ids for the students.

            // return all subjects.
            var subjectsID = _subjectDAL.GetAll().Select(z => z.ID).ToList();
            var subjects = new List<Subject>();

            // select the subjects that are not in the stdSubs list
            foreach (var item in subjectsID)
            {
                if (!stdSubs.Contains(item))
                {
                    subjects.Add(_subjectDAL.GetOne(item));
                }
            }

            return Json(new { subjects },
                JsonRequestBehavior.AllowGet);
        }
    }
}