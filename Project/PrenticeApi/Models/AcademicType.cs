
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrenticeApi.Models
{
    public class AcademicType
    {
        public short AcademicTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ICollection<ProgramType> ProgramTypes { get; set; }
    }
}