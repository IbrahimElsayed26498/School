using System;
using System.Collections.Generic;
using System.Linq;
using School.Models;

namespace School.DAL
{
    public class StudentSubjectDAL
    {
        SchoolDBEntities _db = new SchoolDBEntities();
        public bool Add(StudentSubject studentSubject, out string message)
        {
            try
            {
                if (studentSubject != null)
                {
                    _db.StudentSubjects.Add(studentSubject);
                    _db.SaveChanges();
                    message = "Added Successfuly.";
                    return true;
                }
                else
                {
                    message = "Object is null.";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool Edit(StudentSubject studentSubject, out string message)
        {
            try
            {
                var obj = _db.StudentSubjects.Where(item => item.ID == studentSubject.ID).
                    FirstOrDefault();
                if (obj != null)
                {
                    obj.StudentFK = studentSubject.StudentFK;
                    obj.SubjectFK = studentSubject.SubjectFK;
                    _db.SaveChanges();
                    message = "Edited Successfuly.";
                    return true;
                }
                message = "Object is not found.";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public bool Delete(int id, out string message)
        {
            try
            {
                var obj = _db.StudentSubjects.Where(item => item.ID == id).
                    FirstOrDefault();
                if (obj != null)
                {
                    _db.StudentSubjects.Remove(obj);
                    _db.SaveChanges();
                    message = "Deleted Successfuly.";
                    return true;
                }
                message = "Object is not found.";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public StudentSubject GetOne(int id)
        {
            return _db.StudentSubjects.Where(item => item.ID == id).
                    FirstOrDefault();
        }
        public List<StudentSubject> GetAll()
        {
            return _db.StudentSubjects.ToList();
        }
    }
}