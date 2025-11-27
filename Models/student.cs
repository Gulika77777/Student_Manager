namespace Student_Manager.Models
{
    internal class Student
    {
        private char _grade;
        private int _id;

        public int Id
        {
            get { return _id; }
            init
            {
                if (value != 4)
                {
                    throw new ArgumentException("ID must be 4 digits long.");
                }

                _id = value;
            }
        }

        public string Name { get; set; }

        public int RollNumber { get; set; }
        public char Grade
        {
            get
            {
                return _grade;
            }
            set
            {
                if (value < 'A' || value > 'F')
                {
                    throw new ArgumentException("Grade must be between A and F.");
                }
            }

        }


        public Student(int id, string name, int rollnumber, char grade)
        {
            this.Name = name;
            this.RollNumber = rollnumber;
            this.Grade = grade;
        }

    }

}
