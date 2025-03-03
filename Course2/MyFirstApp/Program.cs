//Console.WriteLine("Enter your name: ");

// string name = "Jake";
// int age = 1111111111;
// age = 4444;
// int age2 = age;
// const int age3 = 22;
//
// string ageAsString = age.ToString();
// int ageAsInt = int.Parse(ageAsString);
// long age1 = 4545545484545454545;
// DateOnly birthday = new DateOnly(19, 1, 1);
// DateTime now = DateTime.Now;
// decimal test = 1.2m;
// float test2 = 1.2f;
// double test3 = 1.2d;
// test3 = age;
// short test4 = 4444;
// Console.WriteLine(now);

// var jakeName = "Jake";
// var myName = "Ali";
// var myAge = 15;
// var myText = $"Hi {jakeName}, my name is {myName}. I am {myAge} years old.";
// Console.WriteLine(myText);
//
// string[] names = { "Ali", "Vali" };
//
// int[] ages = [12, 45];
// var names2 = new string[3];
// names2[0] = "Ali";
// names2[1] = "Vali";
// // names2[2] = "Joni";
// var name = names[1];
//
// foreach (var _name in names2)
//     Console.WriteLine(_name);


// var name = "Ali";
// if (name == "Ali")
// {
//     Console.WriteLine("Enabled");
// }
// else if(name == "Valid")
// {
//
// }
// else if(name == "Jake")
// {
//
// }
// else
// {
//     Console.WriteLine("Disabled");
// }
//
// switch (name)
// {
//     case "Ali":
//         
//         break;
//     case "Vali" when name == "Ali":
//     case "Jake":
//         
//         break;
//     case "Jake2":
//         
//         break;
//     default:
//         Console.WriteLine(name);
//         break;
// }
//
// var day = WeekDays.Saturday;
// switch (day)
// {
//     case WeekDays.Monday:
//         break;
//     case WeekDays.Tuesday:
//         break;
//     case WeekDays.Wednesday:
//         break;
//     case WeekDays.Thursday:
//         break;
//     case WeekDays.Friday:
//         break;
//     case WeekDays.Saturday:
//         break;
//     case WeekDays.Sunday:
//         break;
//     default:
//         throw new ArgumentOutOfRangeException();
// }

var numbers = new int[] { 1, 2, 3, 4, 5 };

// //
// Console.WriteLine("For: ");
// for (int i = 0; i < numbers.Length; i++)
// {
//     var value = numbers[i];
//     if (value % 2 == 0)
//         continue;
//
//     // if (value == 3)
//     //     break;
//
//     Console.WriteLine($"Index: {i}, value: {value}");
// }
//
// Console.WriteLine("Foreach: ");
// foreach(var number in numbers)
//     Console.WriteLine($"Value: {number}");
//
// Console.WriteLine("While: ");
// var index = 0;
// while (index<numbers.Length)
// {
//     var value = numbers[index];
//     Console.WriteLine($"Index: {index}, value: {value}");
//     index++;
//     // index--;
//     // index += 5; //index = index + 5;
//     // index /= 2;
// }
//     
// Console.WriteLine("Do While: ");
// var index2 = 0;
// do
// {
//     var value = numbers[index2];
//     Console.WriteLine($"Index: {index2}, value: {value}");
//     index2++;
// } while (index2 < numbers.Length);
//
// int i = 0;
// for(;;)
// {
//     if(i >= numbers.Length)
//         break;
//         
//     var value = numbers[i];
//     Console.WriteLine($"Index: {i}, value: {value}");
//     i++;
// }
// UserNamePrinter("Brent", 45);
// UserNamePrinter("Jamshed");
// UserNamePrinter("Ali", 15);
// UserNamePrinter("Vali", 10);

// var fullname = FullnameGenerator("Ali", "Aliev");
// Console.WriteLine(fullname);

// var name = "Ali";
// Test(ref name);
// Console.WriteLine(name);
// FullnameGenerator2("Ali", "Aliev", out var fullname);
// Console.WriteLine(fullname);

// var sum = Sum(12, 14, 50, 74, 68);
// Console.WriteLine(sum);

var result = Factorial(4);
Console.WriteLine(result);

Console.WriteLine("End");
return;


// void UserNamePrinter(string name, int age = 18)
// {
//     if (name == "Ali")
//         return;
//
//     Console.WriteLine($"User name is {name}, age is {age}");
// }
//
// string FullnameGenerator(string firstName, string lastName)
// {
//     var fullName = $"{firstName} {lastName}";
//
//     return fullName;
// }

// void Test(ref string firstName)
// {
//     firstName = "newName";
// }

void FullnameGenerator2(string firstName, string lastName, out string fullName)
{
    fullName = InternalFullnameGenerator(firstName, lastName);

    return;
    
    string InternalFullnameGenerator(string firstName, string lastName)
    {
        var fullName = $"{firstName} {lastName}";

        return fullName;
    }
}

int Sum(params int[] numbers)
{
    var sum = 0;
    foreach (var number in numbers)
        sum += number;
    
    return sum;
}

int Factorial(int number)
{
    if (number < 0)
        return 0;
    
    if (number < 1)
        return 1;
    
    return number * Factorial(number - 1);
}

// enum WeekDays
// {
//     Monday,
//     Tuesday,
//     Wednesday,
//     Thursday,
//     Friday,
//     Saturday,
//     Sunday,
// }