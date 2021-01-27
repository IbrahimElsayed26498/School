using System.Collections.Generic;
using System.Linq;
using School.Models;

namespace School.DAL
{
    public class StudentSubjects
    {
        public StudentSubjects(Student student)
        {
            Student = student;
            Subjects = new StudentSubjectDAL().GetAll().
                Where(item => item.StudentFK == student.ID).Select(
                item => new SubjectsDAL().GetOne(item.SubjectFK)
                ).ToList();
        }
        public Student Student { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}