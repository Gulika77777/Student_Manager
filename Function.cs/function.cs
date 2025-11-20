

namespace Student_Manager.Student.cs

namespace Student_Manager.Function.cs
{
    internal class Function
    {
       private List<Student> students = [];

        public bool CreateNewStudent(string name,
                                     int rollNumber,
                                     char grade )
        {

            if (students.Exists(c => c.Name == name))
            {
                throw new ArgumentException("this student is registered");
            }

           students.Add(new Student(name, rollNumber, grade));


            XmlSerializer serializer = new(typeof(List<Student>));

            using (FileStream fs = new FileStream("students.xml", FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
            return true;
        }

    }
}
