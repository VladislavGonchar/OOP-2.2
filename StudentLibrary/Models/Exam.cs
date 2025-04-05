using System;

namespace StudentLibrary.Models
{
    public class Exam : IComparable, ICloneable
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public DateTime ExamDate { get; set; }

        public override string ToString()
        {
            return $"{Subject}: {Grade} ({ExamDate.ToShortDateString()})";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Exam otherExam = obj as Exam;
            if (otherExam != null)
                return string.Compare(this.Subject, otherExam.Subject);
            else
                throw new ArgumentException("Object is not an Exam");
        }

        public object Clone()
        {
            return new Exam
            {
                Subject = this.Subject,
                Grade = this.Grade,
                ExamDate = this.ExamDate
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Exam other)
            {
                return Subject == other.Subject &&
                       Grade == other.Grade &&
                       ExamDate == other.ExamDate;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Subject, Grade, ExamDate);
        }
    }
}
