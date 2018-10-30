
using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class ProgramType
    {
        public short ProgramTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public byte Terms { get; set; }
        public short AcademicTypeId { get; set; }
        public AcademicType AcademicType { get; set; }
        public ICollection<Batch> Batches { get; set; }
    }
}