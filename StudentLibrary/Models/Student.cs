using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLibrary.Models
{
    public class Student : Person, IComparable, ICloneable
    {
        public EducationLevel Level { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public override string ToString()
        {
            double averageGrade = Exams.Count > 0 ? Exams.Average(e => e.Grade) : 0;
            return $"{FirstName} {LastName} - {Level} ({Exams.Count} іспитів, середній бал: {averageGrade:F2})";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Student otherStudent = obj as Student;
            if (otherStudent != null)
                return string.Compare(this.LastName, otherStudent.LastName);
            else
                throw new ArgumentException("Object is not a Student");
        }

        public object Clone()
        {
            // Глибоке клонування
            return new Student
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Level = this.Level,
                Exams = this.Exams.Select(e => (Exam)e.Clone()).ToList()
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return FirstName == other.FirstName &&
                       LastName == other.LastName &&
                       BirthDate == other.BirthDate &&
                       Level == other.Level;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, BirthDate, Level);
        }
    }
}
