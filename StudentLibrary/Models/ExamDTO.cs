﻿using System;

namespace StudentLibrary.Models
{
    public class ExamDTO
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public string ExamDate { get; set; } 

        public override string ToString() => $"{Subject}: {Grade} ({ExamDate})";
    }
}