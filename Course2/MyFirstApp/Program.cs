using System.Collections.Concurrent;
using MyFirstApp.Models;

var cal = new Calculator();
int a = 15;
int b = 10;

var result = cal.Add(a, b);
Console.WriteLine(result);