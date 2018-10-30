
using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class BatchTermCourse
    {
        public short BatchTermCourseId { get; set; }
        public int BatchTermId { get; set; }
        public BatchTerm BatchTerm { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}