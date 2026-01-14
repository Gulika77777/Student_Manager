using Student_Manager.Models;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace Student_Manager.Function
{
    internal class Function
    {
        private List<Student> students = new List<Student>();
        private string filePath = "students.xml";
        private int nextId = 1;

        public Function()
        {
            LoadFromXml();
        }

        public bool CreateNewStudent(string name, int rollNumber, char grade)
        {
            var student = new Student(nextId++, name, rollNumber, grade);
            students.Add(student);
            SaveToXml();
            return true;
        }

        public bool ShowAllStudent()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students registered.");
                return false;
            }

            foreach (var student in students)
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Roll: {student.RollNumber}, Grade: {student.Grade}");

            return true;
        }

        public bool FindStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Roll: {student.RollNumber}, Grade: {student.Grade}");
            return true;
        }

        public bool UpdateStudentGrade(int id, char newGrade)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            student.Grade = newGrade;
            SaveToXml();
            return true;
        }


        public List<Student> SearchByName(string name)
        {
            return students
                .Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }


        public Student SearchByRollNumber(int rollNumber)
        {
            return students.FirstOrDefault(s => s.RollNumber == rollNumber);
        }


        public List<Student> SortByName(bool ascending = true)
        {
            return ascending
                ? students.OrderBy(s => s.Name).ToList()
                : students.OrderByDescending(s => s.Name).ToList();
        }

        public List<Student> SortByGrade(bool ascending = true)
        {
            return ascending
                ? students.OrderBy(s => s.Grade).ToList()
                : students.OrderByDescending(s => s.Grade).ToList();
        }


        public List<Student> SortByRollNumber(bool ascending = true)
        {
            return ascending
                ? students.OrderBy(s => s.RollNumber).ToList()
                : students.OrderByDescending(s => s.RollNumber).ToList();
        }


        public List<Student> FilterByNameAndGrade(string name, char grade)
        {
            return students
                .Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 && s.Grade == grade)
                .ToList();
        }



        private void SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
        }

        private void LoadFromXml()
        {
            if (!File.Exists(filePath)) return;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                students = (List<Student>)serializer.Deserialize(fs);
            }

           
            if (students.Any())
                nextId = students.Max(s => s.Id) + 1;
        }
    }
}
