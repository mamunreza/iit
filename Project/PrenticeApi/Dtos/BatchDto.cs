using System;
using PrenticeApi.Models;

namespace PrenticeApi.Dtos
{
    public class BatchDto
    {
        public short BatchId { get; set; }
        public string Name { get; set; }
        public short ProgramTypeId { get; set; }
        public ProgramType ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short TermTypeId { get; set; }
    }
}