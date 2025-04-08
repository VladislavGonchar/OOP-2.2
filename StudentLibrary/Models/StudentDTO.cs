using System.Collections.Generic;

namespace StudentLibrary.Models
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; } 
        public string Level { get; set; }
        public List<ExamDTO> Exams { get; set; } = new List<ExamDTO>();
    }
}