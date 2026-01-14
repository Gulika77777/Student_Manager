
public abstract class Person
{
    public string Name { get; set; }
    public int RollNumber { get; set; }

    protected Person() { }

    protected Person(string name, int rollNumber)
    {
        Name = name;
        RollNumber = rollNumber;
    }
}
