namespace FirstTestProject;

public class User
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string GetFullName()
    {
        if (string.IsNullOrEmpty(LastName))
        {
            return FirstName;
        }
        
        if (string.IsNullOrEmpty(FirstName))
        {
            return LastName;
        }
        return $"{FirstName} {LastName}";
    }
}