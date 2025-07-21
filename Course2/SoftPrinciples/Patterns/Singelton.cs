namespace SoftPrinciples.Patterns;

public class SmsSender
{
    private SmsSender()
    {
        
    }
    
    private static SmsSender? _instance;

    public static SmsSender Instance
    {
        get
        {
            if (_instance is null)
                _instance = new SmsSender();

            return _instance;
        }
    }
    
    
    public void Send(string message, string email)
    {
        
    }
}