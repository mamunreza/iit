
using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class BatchTerm
    {
        public int BatchTermId { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public short TermTypeId { get; set; }
        public TermType TermType { get; set; }
        public ICollection<BatchTermCourse> BatchCourses { get; set; }
    }
}