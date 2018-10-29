using PrenticeApi.Models;

namespace PrenticeApi.Dtos
{
    public class ProgramTypeDto
    {
        public short ProgramTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public AcademicType AcademicType { get; set; }
    }
}