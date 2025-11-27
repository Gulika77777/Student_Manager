using Student_Manager.Models;
using System.Xml.Serialization;

namespace Student_Manager.Function
{
    internal class Function
    {
        private List<Student> students = new List<Student>();
        private string filePath = "students.xml";

        public bool CreateNewStudent(string name, int rollNumber, char grade)
        {
            var student = new Student(name, rollNumber, grade);

            if (students.Exists(s => s.Id == student.Id))
            {
                throw new ArgumentException("This student is already registered");
            }

            students.Add(student);
            SaveToXml();

            return true;
        }

        public bool ShowAllStudent()
        {
            if (students.Count == 0)
            {
                throw new ArgumentException("No students registered");
            }

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Id: {student.Id}, Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}"
                );
            }

            return true;
        }

        public bool FindStudentById(Guid id)
        {
            var student = students.Find(s => s.Id == id);

            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            Console.WriteLine(
                $"Id: {student.Id}, Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}"
            );

            return true;
        }

        public bool UpdateStudentGrade(Guid id, char newGrade)
        {
            var student = students.Find(s => s.Id == id);

            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            student.Grade = newGrade;
            SaveToXml();

            return true;
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
        }
    }
}
