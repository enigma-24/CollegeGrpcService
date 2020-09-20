using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI.Data;
using CollegeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeAPI.Controllers
{
    [Route("api/collegeapi")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly CollegeContext context;

        public StudentCourseController()
        {
            context = new CollegeContext();
        }

        [HttpGet("studentcourses/{id}")]
        public StudentCourse GetStudentCourse(int id)
        {
            return context.StudentCourses.Where(s => s.StudentCourseID == id).FirstOrDefault();
        }

        [HttpGet("studentcourses")]
        public List<StudentCourse> GetAllStudents()
        {
            return context.StudentCourses.ToList();
        }

        [HttpPost("studentcourses")]
        public IActionResult AddStudentCourse([FromBody] StudentCourse studentCourse)
        {
            context.StudentCourses.Add(studentCourse);
            context.SaveChanges();
            return Ok();
        }


        [Route("studentcourses/{id}")]
        public IActionResult DeleteStudentCourse(int id)
        {
            context.Remove(context.StudentCourses.Where(s => s.StudentCourseID == id).FirstOrDefault());
            context.SaveChanges();
            return Ok();
        }
    }
}
