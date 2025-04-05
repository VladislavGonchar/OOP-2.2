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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МЕНЮ ===");
                Console.WriteLine("1. Згенерувати випадкових студентів і зберегти у JSON");
                Console.WriteLine("2. Завантажити студентів з JSON і вивести");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GenerateAndSave();
                        break;
                    case "2":
                        LoadAndDisplay();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Натисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GenerateAndSave()
        {
            var students = GenerateRandomStudents(5);
            JsonStorage.Save(students);
            Console.WriteLine("\nЗгенеровано та збережено у students.json");
            Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }

        static void LoadAndDisplay()
        {
            var students = JsonStorage.Load();
            Console.WriteLine("\n== Завантажені студенти ==\n");

            foreach (var student in students)
            {
                Console.WriteLine(student);
                foreach (var exam in student.Exams)
                {
                    Console.WriteLine("  " + exam);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }

        static List<Student> GenerateRandomStudents(int count)
        {
            var random = new Random();
            var firstNames = new[] { "Влад", "Олена", "Ігор", "Марія", "Дмитро" };
            var lastNames = new[] { "Шевченко", "Коваль", "Бондар", "Ткаченко", "Сидоренко" };
            var subjects = new[] { "Математика", "Програмування", "Фізика", "Англійська", "Хімія" };
            var levels = Enum.GetValues(typeof(EducationLevel));

            var students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                var student = new Student
                {
                    FirstName = firstNames[random.Next(firstNames.Length)],
                    LastName = lastNames[random.Next(lastNames.Length)],
                    BirthDate = DateTime.Today.AddYears(-random.Next(18, 25)).AddDays(-random.Next(0, 365)),
                    Level = (EducationLevel)levels.GetValue(random.Next(levels.Length))
                };

                int examsCount = random.Next(1, 4);
                for (int j = 0; j < examsCount; j++)
                {
                    student.Exams.Add(new Exam
                    {
                        Subject = subjects[random.Next(subjects.Length)],
                        Grade = random.Next(60, 101),
                        ExamDate = DateTime.Today.AddDays(-random.Next(1, 300))
                    });
                }

                students.Add(student);
            }

            return students;
        }
    }
}
