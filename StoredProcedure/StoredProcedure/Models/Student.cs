using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StoredProcedure.Models
{
    public class Student
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
    }
}
