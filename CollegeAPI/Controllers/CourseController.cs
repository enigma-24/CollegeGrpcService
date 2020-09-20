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
    public class CourseController : ControllerBase
    {
        private readonly CollegeContext context;

        public CourseController()
        {
            context = new CollegeContext();
        }

        [HttpGet]
        [Route("courses/{id}")]
        public Course GetCourse(int id)
        {
            return context.Courses.Where(c => c.CourseID == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("courses")]
        public List<Course> GetAllCourses()
        {
            return context.Courses.ToList();
        }

        [HttpPost]
        [Route("courses")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            context.Add(course);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("courses/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            context.Remove(context.Courses.Where(c => c.CourseID == id).FirstOrDefault());
            context.SaveChanges();
            return Ok();
        }
    }
}
