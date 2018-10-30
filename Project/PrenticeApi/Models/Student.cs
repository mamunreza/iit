
using System;
using System.Collections.Generic;

namespace PrenticeApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RollNo { get; set; }
        public DateTime Dob { get; set; }
    }
}