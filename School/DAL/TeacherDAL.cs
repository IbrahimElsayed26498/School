using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School.Models;
namespace School.DAL
{
    public class TeacherDAL
    {
        Models.SchoolDBEntities _db = new Models.SchoolDBEntities();
        public bool Add(Teacher teacher, out string message)
        {
            try
            {
                if (teacher != null)
                {
                    _db.Teachers.Add(teacher);
                    _db.SaveChanges();
                    message = "Added Successfully.";
                    return true;
                }
                message = "Teacher object is null.";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool Edit(Teacher teacher, out string message)
        {
            try
            {
                var obj = _db.Teachers.Where(item => item.ID == teacher.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = teacher.Name;
                    _db.SaveChanges();
                    message = "Edited Successfully.";
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
        public bool Delete(int id, out string message)
        {
            try
            {
                var obj = _db.Teachers.Where(item => item.ID == id).FirstOrDefault();
                if (obj != null)
                {
                    _db.Teachers.Remove(obj);
                    _db.SaveChanges();
                    message = "Deleted Successfully.";
                    return true;
                }
                message = "Object is not found";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        public Teacher GetOne(int id)
        {
            return _db.Teachers.Where(item => item.ID == id).FirstOrDefault();
        }
        public List<Teacher> GetAll()
        {
            return _db.Teachers.ToList();
        }
    }
}