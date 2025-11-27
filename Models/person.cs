

public abstract class  Person
{
    public string name   { get; set; }
    public int rollnumber { get; set; }


     protected Person()
    {
        
    }
    protected Person( string name, int rollnumber)
    {
        this.name = name;
        this.rollnumber = rollnumber;
    }
}

