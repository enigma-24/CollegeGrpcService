using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAPI.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseID { get; set; }
        
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}