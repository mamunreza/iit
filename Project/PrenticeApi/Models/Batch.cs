
using System;
using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string Name { get; set; }
        public short ProgramTypeId { get; set; }
        public ProgramType ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public ICollection<BatchTerm> BatchTerms { get; set; }
    }
}