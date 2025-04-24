using System.Collections.Concurrent;
using MyFirstApp.Models;

var cal = new Calculator<int>();
cal.MultiplyCount = 3;
int a = 2;
int b = 3;

var sum = cal.Add(a, b);
// var result = cal.Subtract(a, b);

var result = cal.Multiply(a, b);
Console.WriteLine(result);