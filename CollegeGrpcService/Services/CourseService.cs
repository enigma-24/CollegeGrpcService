using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI.Controllers;
using CollegeGrpcService.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using static CollegeGrpcService.Protos.Course;
using Course = CollegeAPI.Models.Course;

namespace CollegeGrpcService
{
    public class CourseService: CourseBase
    {
        private readonly CourseController logic;

        public CourseService()
        {
            logic = new CourseController();
        }

        public override Task<CourseReply> GetCourse(CourseIdRequest request, ServerCallContext context)
        {
            Course course = logic.GetCourse(request.CourseID);
            return Task.FromResult<CourseReply>(FromPoco(course));
        }

        public override Task<Courses> GetAllCourses(Empty request, ServerCallContext context)
        {
            Courses courses = new Courses();
            List<Course> allCourses = logic.GetAllCourses();
            foreach (var course in allCourses)
            {
                courses.Reply.Add(FromPoco(course));
            }
            return Task.FromResult<Courses>(courses);
        }

        public override Task<Empty> AddCourse(CourseReply request, ServerCallContext context)
        {
            Course course = new Course
            {
                CourseID = request.CourseID,
                CourseName = request.CourseName
            };
            logic.AddCourse(course);
            return Task.FromResult(new Empty());

        }

        private CourseReply FromPoco(Course poco)
        {
            return new CourseReply
            {
                CourseID = poco.CourseID,
                CourseName = poco.CourseName
            };
        }

        private Course ToPoco(CourseReply reply)
        {
            return new Course
            {
                CourseID = reply.CourseID,
                CourseName = reply.CourseName
            };
        }
    }
}
