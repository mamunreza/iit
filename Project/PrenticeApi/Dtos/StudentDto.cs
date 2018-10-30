using System;
using PrenticeApi.Models;

namespace PrenticeApi.Dtos
{
    public class StudentDto
    {
        public short StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNo { get; set; }
        public string RollNo { get; set; }
        public DateTime Dob { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}