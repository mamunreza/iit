
using System.ComponentModel.DataAnnotations.Schema;

namespace PrenticeApi.Models
{
    public class ProgramType
    {
        public short ProgramTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public short AcademicTypeId { get; set; }
        public AcademicType AcademicType { get; set; }
    }
}