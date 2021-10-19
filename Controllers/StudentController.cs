using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication31DropDown.Models;

namespace WebApplication31DropDown.Controllers
{
    public class StudentController : Controller
    {
        public IStudent Student { get; }
        public StudentController(IStudent _student)
        {
            Student=_student;
        }

        public IActionResult Create()
        {
            ViewBag.course = (from a in Student.GetCourses() select a);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            Student.AddStudent(student);
            return RedirectToAction("Show");
        }
        public IActionResult Show() {
            var data = (from a in Student.GetStudent()
                        join b in Student.GetCourses() on a.Course equals b.Cid
                        select new ShowDatausingJoin
                        {
                            Sid = a.Sid,
                            Name = a.Name,
                            Email = a.Email,
                            Phone = a.Phone,
                            CourseName = b.Cname
                        }).ToList();
            return View(data);
        }
        public IActionResult Delete(int id) {
            Student.DeleteStudent(id);
            return RedirectToAction("Show");
        }
        public IActionResult Edit(int id) {
            var data=Student.EditStudent(id);
            ViewBag.course = (from a in Student.GetCourses() select a);
            return View(data);
        }
        public IActionResult Update(Student student) {
            Student.UpdateStudent(student);
            return RedirectToAction("Show");
        }
    }
}
