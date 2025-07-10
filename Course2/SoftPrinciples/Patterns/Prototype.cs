namespace SoftPrinciples;

public abstract class Person
{
    public string FirstName { get; set; }
    public int Age { get; set; }
    public int LastName { get; set; }

    protected Person Clone(Person person)
    {
        person.FirstName = FirstName;
        person.LastName = LastName;
        person.Age = Age;
        return person;
    }
}

public class Student : Person
{
    public string School { get; set; }
    
    public Student Clone()
    {
        var student = new Student
        {
            School = School
        };
        base.Clone(student);
        
        return student;
    }
}

public class Teacher : Person
{
    public string Subject { get; set; }
    
    public Teacher Clone()
    {
        var teacher = new Teacher
        {
            Subject = Subject
        };
        base.Clone(teacher);
        
        return teacher;
    }
}