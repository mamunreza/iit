using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenticeApi.Models
{
    public class BatchTermStudent
    {
        public short BatchTermStudentId { get; set; }
        public int BatchTermId { get; set; }
        public BatchTerm BatchTerm { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
