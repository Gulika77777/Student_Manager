

namespace Student_Manager.Student.cs

namespace Student_Manager.Function.cs
{
    internal class Function
    {
       private List<Student> students = [];

        public bool CreateNewStudent(int id,
                                     string name,
                                     int rollNumber,
                                     char grade )
        {

            if (students.Exists(c => c.Id == id))
            {
                throw new ArgumentException("this student is registered");
            }

           students.Add(new Student(id ,name, rollNumber, grade));


            XmlSerializer serializer = new(typeof(List<Student>));

            using (FileStream fs = new FileStream("students.xml", FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
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
                Console.WriteLine($" Id:{student.Id}, Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
            return true;

        }

        public bool FindStudentById(int id)
        {
            var student = students.Find(c => c.Id == id);
            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }
            Console.WriteLine($" Id:{student.Id}, Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            return true;
        }

        public bool UpdateStudentGrade(int id, char newGrade)
        {
            var student = students.Find(c => c.Id == id);
            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }
            student.Grade = newGrade;
            XmlSerializer serializer = new(typeof(List<Student>));
            using (FileStream fs = new FileStream("students.xml", FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
            return true;
        }

    }
}
