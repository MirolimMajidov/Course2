namespace MyFirstApp.Models;

public static class Extensions
{
    public static void Printer(this User user, string text)
    {
        SmsSender.Send(text);
        
        Console.WriteLine(text);
    }
    
    
    public static void Sum(this int amount, int additional)
    {
        Console.WriteLine(amount + additional);
    }
}