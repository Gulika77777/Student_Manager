public abstract class Person
{
    public string Name { get;  set; } = string.Empty;
    public int RollNumber { get;  set; }

    protected Person() { }

    protected Person(string name, int rollNumber)
    {
       this.Name = name;
        this.RollNumber = rollNumber;
    }



  

    public override string ToString()
    {
        return $"Name: {Name}, Roll Number: {RollNumber}";
    }
}

