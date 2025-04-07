using System.Collections.Concurrent;
using MyFirstApp.Models;

Dictionary<string, string> dic = new Dictionary<string, string>();
dic.Add("Key", "Value");

var dic2 = new ConcurrentDictionary<string, string>();
dic2.TryAdd("Key", "Value");

var user = new User() { Balance = 100 };

var task1 = Task.Run(() =>
{
    user.Withdraw(50);
});
var task2 = Task.Run(() =>
{
    user.Withdraw(50);
});
var task3 = Task.Run(() =>
{
    user.Withdraw(50);
});

Task.WaitAll(task1, task2, task3);
Console.WriteLine(user.Balance);