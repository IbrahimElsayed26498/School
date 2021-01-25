using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School.Models;

namespace School.DAL
{
    public class TeacherStudnetsSubjects
    {
        public TeacherStudnetsSubjects
            (Teacher teacher)
        {
            this.teacher = teacher;
            studentSubjects = new List<StudentSubjects>();
            foreach (var item in new StudentsDAL().GetAll().
                Where(item => item.TeacherFK == teacher.ID).ToList())
            {
                studentSubjects.Add(new StudentSubjects(item));
            }
        }
        public Teacher  teacher{ get; set; }
        public List<StudentSubjects> studentSubjects { get; set; }
    }
}