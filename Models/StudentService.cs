using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication31DropDown.Models
{
    public class StudentService : IStudent
    {
        public DatabaseContext Context { get; }

        public StudentService(DatabaseContext context)
        {
            Context = context;
        }
        public Student AddStudent(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
            return student;
        }
        public List<Student> GetStudent()
        {
            return Context.Students.ToList();
        }

        public Student DeleteStudent(int id)
        {
            var deleteID = Context.Students.SingleOrDefault(x => x.Sid == id);
            Context.Remove(deleteID);
            Context.SaveChanges();
            return deleteID;
        }

        public Student EditStudent(int id)
        {
            var editId = Context.Students.SingleOrDefault(x => x.Sid == id);
            return editId;
        }

        public Student UpdateStudent(Student student)
        {
            var data = Context.Students.SingleOrDefault(x => x.Sid == student.Sid);
            data.Sid = student.Sid;
            data.Name = student.Name;
            data.Email = student.Email;
            data.Phone = student.Phone;
            data.Course = student.Course;
            Context.Students.Update(data);
            Context.SaveChanges();
            return data;
        }

        public List<Course> GetCourses()
        {
            return Context.Courses.ToList();
        }
    }
}
