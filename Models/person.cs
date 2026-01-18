public abstract class Person
{
    public string Name { get; protected set; } = string.Empty;
    public int RollNumber { get; protected set; }

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

