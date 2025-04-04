using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StudentLibrary.Models;

namespace StudentLibrary
{
    public static class Converters
    {
        public static ExamDTO ToDTO(this Exam exam)
        {
            return new ExamDTO
            {
                Subject = exam.Subject,
                Grade = exam.Grade,
                ExamDate = exam.ExamDate.ToString("yyyy-MM-dd")
            };
        }

        public static Exam ToEntity(this ExamDTO dto)
        {
            return new Exam
            {
                Subject = dto.Subject,
                Grade = dto.Grade,
                ExamDate = DateTime.ParseExact(dto.ExamDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
        }

        public static StudentDTO ToDTO(this Student student)
        {
            return new StudentDTO
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate.ToString("yyyy-MM-dd"),
                Level = student.Level.ToString(),
                Exams = student.Exams.Select(e => e.ToDTO()).ToList()
            };
        }

        public static Student ToEntity(this StudentDTO dto)
        {
            return new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = DateTime.ParseExact(dto.BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Level = Enum.Parse<EducationLevel>(dto.Level),
                Exams = dto.Exams.Select(e => e.ToEntity()).ToList()
            };
        }
    }
}