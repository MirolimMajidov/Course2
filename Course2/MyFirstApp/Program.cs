// var numbers = new List<int>()
// {
//     1, 2, 3, 4, 5, 6, 7, 8, 9, 10
// };
// numbers.Add(14);
// numbers.Insert(1, 15);
// numbers.Remove(5);
// numbers.RemoveAt(2);
// numbers.AddRange(4, 55, 69);
//
// foreach (int number in numbers)
// {
//     Console.WriteLine(number);
// }
//
// using System.Collections.Concurrent;
//
// var countries = new Dictionary<string, string>();
// countries.Add("TJ", "Tajikistan");
// countries.Add("UZ", "Uzbekistan");
//
// countries["RU"] = "Russia";
// countries["RU"] = "Russia Federation";
//
// var name1 = countries["RU"];
// foreach (var (code, name) in countries)
// {
//     Console.WriteLine($"{code}: {name}");
// }
// var dictionary = new ConcurrentDictionary<string, string>();
// dictionary.TryAdd("TJ", "Tajikistan");
// var result = dictionary.TryGetValue("TJ", out var value);

// var numbers = new int[] { 14, 45, 65, 14 };
// var numbersAsSpan = numbers.AsSpan();

using MyFirstApp.Models;

Queue<User> usersQueue = new Queue<User>();
usersQueue.Enqueue(new User { FirstName = "Ali" });
usersQueue.Enqueue(new User { FirstName = "Vali" });
usersQueue.Enqueue(new User { FirstName = "Joni" });

foreach (var user in usersQueue)
{
    Console.WriteLine(user.FirstName);
}
var user1 = usersQueue.Dequeue();
var user2 = usersQueue.Dequeue();


Console.WriteLine("End");
// using MyFirstApp.Models;
//
// User.UserCreated += UserCreatedHandler1;
// User.UserCreated += UserCreatedHandler2;
//
// var user = new User
// {
//     FirstName = "Ali",
//     LastName = "Valievich",
//     OnStartingWork = UserWorking
// };
// user.DoWork();
// user.DoWork();
// user.OnStartingWork -= UserWorking;
//
// user.OnStartingWork += (sender, args) =>
// {
//     Console.WriteLine("User working");
// };
// user.DoWork();
//
//
// Console.WriteLine("End");
//
// void UserCreatedHandler1(object sender, EventArgs e)
// {
//     if(sender is User user)
//         Console.WriteLine($"User created1: {user.FirstName}");
//     
//     Console.WriteLine("User created1");
// }
//
// void UserCreatedHandler2(object sender, DoWorkEventArgs e)
// {
//     Console.WriteLine($"User created1: {e.UserName}");
//     Console.WriteLine("User created2");
// }
//
// void UserWorking(object sender, EventArgs e)
// {
//     Console.WriteLine("User working");
// }