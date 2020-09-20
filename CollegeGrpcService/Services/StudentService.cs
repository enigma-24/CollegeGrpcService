using CollegeAPI.Controllers;
using CollegeGrpcService.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CollegeGrpcService.Protos.Student;
using Student = CollegeAPI.Models.Student;

namespace CollegeGrpcService.Services
{
    public class StudentService: StudentBase
    {
        private readonly StudentController logic;

        public StudentService()
        {
            logic = new StudentController();
        }

        public override Task<StudentReply> GetStudent(StudentIdRequest request, ServerCallContext context)
        {
            Student student = logic.GetStudent(request.StudentID);
            return Task.FromResult<StudentReply>(FromPoco(student));
        }

        public override Task<Students> GetAllStudents(Empty request, ServerCallContext context)
        {
            Students students = new Students();
            List<Student> allStudents = logic.GetAllStudents();
            foreach (var student in allStudents)
            {
                students.Reply.Add(FromPoco(student));
            }
            return Task.FromResult<Students>(students);
        }

        public override Task<Empty> AddStudent(StudentReply request, ServerCallContext context)
        {
            Student student = new Student
            {
                StudentID = request.StudentID,
                StudentName = request.Name
            };
            logic.AddStudent(student);
            return Task.FromResult(new Empty());
        }

        private StudentReply FromPoco(Student poco)
        {
            return new StudentReply
            {
                StudentID = poco.StudentID,
                Name = poco.StudentName
            };
        }

        private Student ToPoco(StudentReply reply)
        {
            return new Student
            {
                StudentID = reply.StudentID,
                StudentName = reply.Name
            };
        }
    }
}
