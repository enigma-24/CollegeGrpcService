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
    public class StudentController : ControllerBase
    {
        private readonly CollegeContext context;
        public StudentController()
        {
            context = new CollegeContext();
        }

        [HttpGet("students/{id}")]
        public Student GetStudent(int id)
        {
            return context.Students.Where(s => s.StudentID == id).FirstOrDefault();
        }

        [HttpGet("students")]
        public List<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }

        [HttpPost("students")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return Ok();
        }


        [Route("students/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            context.Remove(context.Students.Where(s => s.StudentID == id).FirstOrDefault());
            context.SaveChanges();
            return Ok();
        }
    }
}
