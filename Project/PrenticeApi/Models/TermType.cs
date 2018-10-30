
using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class TermType
    {
        public short TermTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<BatchTerm> BatchTerms { get; set; }
    }
}