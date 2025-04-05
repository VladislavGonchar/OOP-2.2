using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using StudentLibrary.Models;

namespace StudentLibrary.Serialization
{
    public static class JsonStorage
    {
        
        private const string FileName = @"C:\Users\vladg\source\repos\StudentManagerSolution\students.json";

        public static void Save(List<Student> students)
        {
            var dtos = students.Select(s => s.ToDTO()).ToList();
            var json = JsonConvert.SerializeObject(dtos, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }

        public static List<Student> Load()
        {
            if (!File.Exists(FileName))
                return new List<Student>();

            var json = File.ReadAllText(FileName);
            var dtos = JsonConvert.DeserializeObject<List<StudentDTO>>(json);
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }
    }
}