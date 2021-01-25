using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School.Models;

namespace School.DAL
{
    public class StudentsDAL
    {
        SchoolDBEntities _db = new SchoolDBEntities();
        public bool Add(Student student, out string message)
        {
            try
            {
                if (student != null)
                {
                    _db.Students.Add(student);
                    _db.SaveChanges();
                    message = "Added Successfully.";
                    return true;
                }
                else
                {
                    message = "Student Object is null";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool Edit(Student student, out string message)
        {
            try
            {
                var obj = _db.Students.Where(item => item.ID == student.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = student.Name;
                    obj.TeacherFK = student.TeacherFK;
                    _db.SaveChanges();
                    message = "Added Successfully";
                    return true;
                }
                else
                {
                    message = "Object is null";
                    return false;
                }
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
                var obj = _db.Students.Where(item => item.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    _db.Students.Remove(obj);
                    _db.SaveChanges();
                    message = "Deleted Successfully.";
                    return true;
                }
                else
                {
                    message = "Object is not found.";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public Student GetOne(int id)
        {
            return _db.Students.Where(item => item.ID == id).FirstOrDefault();
        }
        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }
    }
}