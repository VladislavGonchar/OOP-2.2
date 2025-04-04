// Class: Student (add IComparable, ICloneable)
using System;
using System.Collections.Generic;

namespace StudentLibrary.Models
{
    public class Student : Person, IComparable, ICloneable
    {
        public EducationLevel Level { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Level} ({Exams.Count} іспитів)";
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
            return this.MemberwiseClone();
        }
    }
}