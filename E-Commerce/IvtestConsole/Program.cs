// See https://aka.ms/new-console-template for more information


public class myClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class InstanceClass
{
    public static void AddPersonDetails()
    {
        myClass cls=new myClass();
        {
            cls.Id = 1;
            cls.Name = "Test";
            cls.Age = 30;
        };
        {
            cls.Id = 2;
            cls.Name = "Best";
            cls.Age = 20;
        };

        Console.WriteLine(cls);
    }
    
    
}