using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication31DropDown.Models
{
    public interface IStudent
    {
        Student AddStudent(Student student);
        List<Student> GetStudent();
        Student DeleteStudent(int id);
        Student EditStudent(int id);
        Student UpdateStudent(Student student);
        List<Course> GetCourses();
    }
}
