// Action<string> notifier = null;
//
// notifier = MyNotifier.TelegramNotifier;
// notifier("Test1");
// notifier("Test2");
//
// notifier = MyNotifier.EmailSender;
// notifier("Test3");
//
// notifier = MyNotifier.SmsSender;
// notifier("Test4");

Notifier2 notifier2 = TestMethod;
var result = notifier2("Hi");

Func<string, string> notifier3 = TestMethod;
var result2 = notifier3("Hi");

//using MyFirstApp.Models;
// var user = new User(TestMethod)
// {
//     LastName = ""
// };


// var user2 = new User(MyNotifier.SmsSender)
// {
//     LastName = ""
// };


Console.WriteLine("End...");


string TestMethod(string message)
{
    return $"Tester : {message}";
}

delegate void Notifier(string message);
delegate string Notifier2(string message);

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