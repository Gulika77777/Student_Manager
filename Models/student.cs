using System;

namespace Student_Manager.Models
{
    public class Student : Person
    {
        private char _grade;

        public Guid Id { get; private set; }

        public char Grade
        {
            get => _grade;
            set
            {
                if (value < 'A' || value > 'F')
                {
                    throw new ArgumentException("Grade must be between A and F.");
                }
                _grade = value;
            }
        }

        public object Name { get; internal set; }
        public object RollNumber { get; internal set; }

        public Student()
        {
            Id = Guid.NewGuid();
        }

        public Student(string name, int rollNumber, char grade)
            : base(name, rollNumber)
        {
            Id = Guid.NewGuid();
            Grade = grade;
        }
    }
}
