using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using static CollegeGrpcService.Protos.Course;

namespace CollegeGrpcService
{
    public class CourseService: CourseBase
    {
        public CourseService()
        {

        }
    }
}
