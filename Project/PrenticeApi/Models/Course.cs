using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        //public decimal Credit { get; set; }
        public ICollection<BatchTermCourse> BatchTermCourses { get; set; }
        
    }
}