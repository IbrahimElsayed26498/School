using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.DAL
{
    public class SubjectsDAL
    {
        SchoolDBEntities _db = new SchoolDBEntities();
        public SubjectsDAL()
        {
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public bool Add(Subject subject, out string message)
        {
            try
            {
                if (subject!=null)
                {
                    _db.Subjects.Add(subject);
                    _db.SaveChanges();
                    message = "Added Successfully";
                    return true;
                }
                message = "Empty subject";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool Edit(Subject subject, out string message)
        {
            try
            {
                var obj = _db.Subjects.Where(item => item.ID == subject.ID).FirstOrDefault();
                if (obj != null)
                {
                    obj.Name = subject.Name;
                    _db.SaveChanges();
                    message = "Edited Successfully";
                    return true;
                }
                else
                {
                    message = "Empty subject";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        public bool Delete(Subject subject, out string message)
        {
            try
            {
                var obj = _db.Subjects.Where(item => item.ID == subject.ID).FirstOrDefault();
                if (obj != null)
                {
                    _db.Subjects.Remove(obj);
                    _db.SaveChanges();
                    message = "Deleted Successfully";
                    return true;
                }
                else
                {
                    message = "Empty subject";
                    return false;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        
        public Subject GetOne(int id)
        {
            return _db.Subjects.Where(item => item.ID == id).FirstOrDefault();
        }

        public List<Subject> GetAll()
        {
            return _db.Subjects.ToList();
        }
    }
}