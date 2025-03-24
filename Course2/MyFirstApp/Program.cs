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

// using System.Collections;
//
// var countries = new Dictionary<string, string>();
// countries.Add("TJ", "Tajikistan");
// countries.Add("UZ", "Uzbekistan");
//
// if (countries.ContainsValue("TJ"))
// {
// }
// countries.TryAdd("TJ", "Tajikistan");
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

// using MyFirstApp.Models;

// Queue<User> usersQueue = new Queue<User>();
// usersQueue.Enqueue(new User { FirstName = "Ali" });
// usersQueue.Enqueue(new User { FirstName = "Vali" });
// usersQueue.Enqueue(new User { FirstName = "Joni" });
//
// foreach (var user in usersQueue)
// {
//     Console.WriteLine(user.FirstName);
// }
// var user1 = usersQueue.Dequeue();
// var user2 = usersQueue.Dequeue();

// Stack<User> users = new Stack<User>();
// users.Push(new User { FirstName = "Ali" });
// users.Push(new User { FirstName = "Ali" });
// var item = users.Pop();

// var countryNames = new HashSet<string>();
// countryNames.Add("Tajikistan");
// countryNames.Add("Uzbekistan");
//
// if (countryNames.Contains("Tajikistan"))
// {
//     
// }
//
// var numbers = new List<int> { 1, 2, 3, 9, 4, 5, 6, 7, 8, 10 };
// var filteredNumbers = numbers.Where(n => n % 2 == 0 && n != 6)
//     .Skip(2)
//     .Take(4)
//     .OrderBy(n => n)
//     .ToList().AsReadOnly();
// foreach (var number in filteredNumbers)
// {
//     Console.WriteLine(number);
// }
// foreach (var number in filteredNumbers)
// {
//     Console.WriteLine(number);
// }
//
// Console.WriteLine("New For");
// numbers.Remove(4);
// foreach (var number in filteredNumbers)
// {
//     Console.WriteLine(number);
// }

using MyFirstApp.Models;

var users = new List<User>();

users.Add(new User { FirstName = "Ali", Age = 15});
users.Add(new User { FirstName = "Ali2", Age = 21});
users.Add(new User { FirstName = "Vali", Age = 35 });
users.Add(new User { FirstName = "Jake", Age = 55 });
users.Add(new User { FirstName = "Jami", Age = 40 });
users.Add(new User { FirstName = "Joni", Age = 55 });
var filteredUsers = users.Where(u=>
        u.Age > 20 
        && u.Age < 80 
        && u.FirstName != "Vali" 
        && u.FirstName.Contains("i"))
    .Skip(1)
    .Take(4)
    .OrderBy(n => n.FirstName)
    .ToList();
foreach (var user in filteredUsers)
{
    Console.WriteLine(user.FirstName);
}

// var countries = new Dictionary<string, string>();
// countries.Add("TJ", "Tajikistan");
// countries.Add("UZ", "Uzbekistan");


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
//
// var list = new MyList<int>();
// list.Add(5);
// list.Add(523);
// list.Add(53);
// list.Add(235);
// list.Add(35);
// list.Remove(235);
//
// foreach (var item in list)
// {
//     Console.WriteLine(item);
// }
//
// public class MyList<T> : IEnumerable<T>
// {
//     List<T> list = new List<T>();
//     
//     public void Add(T item)
//     {
//         list.Add(item);
//     }
//     
//     public void Remove(T item)
//     {
//         list.Remove(item);
//     }
//     
//     public IEnumerator<T> GetEnumerator()
//     {
//         for (int i = 0; i < list.Count; i+=2)
//         {
//             yield return list[i];
//         }
//     }
//
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }