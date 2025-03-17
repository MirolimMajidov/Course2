//Notifier notifier = null;

// notifier = MyNotifier.TelegramNotifier;
// notifier("Test1");
// notifier("Test2");
//
// notifier = MyNotifier.EmailSender;
// notifier("Test3");
//
// notifier = MyNotifier.SmsSender;
// notifier("Test4");

using MyFirstApp.Models;

var user = new User(MyNotifier.TelegramNotifier)
{
    LastName = ""
};


var user2 = new User(MyNotifier.SmsSender)
{
    LastName = ""
};


Console.WriteLine("End...");


delegate void Notifier(string message);

public static class MyNotifier
{
    public static void TelegramNotifier(string message)
    {
        Console.WriteLine($"Telegram : {message}");
    }

    public static void EmailSender(string message)
    {
        Console.WriteLine($"Email : {message}");
    }

    public static void SmsSender(string message)
    {
        Console.WriteLine($"Sms : {message}");
    }
}