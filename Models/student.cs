using System;

namespace Student_Manager.Models
{
    public class Student : Person
    {
        private char _grade;

        public int Id { get; set; }  

        public char Grade
        {
            get => _grade;
            set
            {
                if (value < 'A' || value > 'F')
                    throw new ArgumentException("Grade must be between A and F.");
                _grade = value;
            }
        }

        public Student() { } 
        public Student(int id, string name, int rollNumber, char grade)
            : base(name, rollNumber)
        {
            Id = id;
            Grade = grade;
        }

        public Student(string name, int rollNumber, char grade) : base(name, rollNumber)
        {
        }

        public override string ToString()
        {
            return $"{Id}: {Name}, Roll: {RollNumber}, Grade: {Grade}";
        }
    }
}
