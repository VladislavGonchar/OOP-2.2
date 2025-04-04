using System;
using System.Collections.Generic;
using StudentLibrary.Models;
using StudentLibrary.Serialization;

namespace StudentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = JsonStorage.Load();

            if (students.Count == 0)
            {
                Console.WriteLine("Немає студентів у базі!");
            }
            else
            {
                Console.WriteLine("Список студентів:");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}, {student.Level}, Дата народження: {student.BirthDate.ToShortDateString()}");
                }
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}