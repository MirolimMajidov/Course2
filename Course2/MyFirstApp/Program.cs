
// Permission firstUserAccess = Permission.Read;
// Permission secondUserAccess = Permission.Read | Permission.Modify;
//
// if ((secondUserAccess & Permission.Read) is Permission.Read)
// {
//     Console.WriteLine("Has read permission");
// }
// if ((secondUserAccess &  Permission.Create) is Permission.Create)
// {
//     Console.WriteLine("Has create permission");
// }
// if ((secondUserAccess &  Permission.Modify) is Permission.Modify)
// {
//     Console.WriteLine("Has modify permission");
// }
// Console.WriteLine(firstUserAccess);
// Console.WriteLine(secondUserAccess);

// var user = Tuple.Create("Aliev", "Ali", 15);
// var user2 = Tuple.Create("Aliev", "Ali", 15);
// var user5 = ("Jake", 45);
//
// Console.WriteLine($"User name is {user.Item2} last name is {user.Item1}, age is {user.Item3}");
//
// var userInfo = GetUserInformation(user);
// var (name, age) = GetUserInformation(user);
// Console.WriteLine($"User name is {name}, age is {age}");

using System.Text;
using MyFirstApp.Models;
using MyFirstApp.Models.Credit;
using MyFirstApp.Models.Deposit;

//User.Printer("Test method");

int age = 10;
var day = 10;

int? age2 = null;
if (day == 15)
{
    age2 = 45;
}

var ageAsString = age2.GetHashCode();
if (age2 != null)
{
    var ageAsString2 = age2.ToString();
}
if (age2 is not null)
{
    var ageAsString2 = age2.ToString();
}
if (age2.HasValue)
{
    var ageAsString2 = age2.ToString();
}

age.Sum(5);

string name2 = null;
var name = "";
string name3 = "";
string name4 = string.Empty;
string name5 = string.Empty;

string[] names = ["Ali", "Vali", "Jake", "Jake2"];
var allNames = string.Empty;
foreach (var _name in names)
{
    allNames += _name;
}
//O1 = 0
//O2 = 5
//O3 = 10
//O4 = 15
//O5 = 20
var nameBuilder = new StringBuilder();
foreach (var _name in names)
{
    nameBuilder.Append(_name);
}
var allNames2 = nameBuilder.ToString(); //20



User user1 = null;
user1 = new User(1)
{
    FirstName = "Ali",
    LastName = "Kowalski",
    Email = ""
};


var ali = new User(1)
{
    FirstName = "Alex",
    LastName = "Kowalski",
    Email = "alexkowalski@gmail.com",
};
ali.DoWork();

Extensions.Printer(ali, "dssd");
ali.Printer("Test");

var id = ali.Id;
ali.Age = 45;

ali.Age.Sum(5);

var userDTO = new UserDTO();
userDTO.Id = userDTO.Id;
userDTO.FirstName = ali.FirstName;
userDTO.Email = ali.Email;


var credit = new TemporaryCredit();


userDTO.Email = "sdsdfsd";

var vali = new User(2, "Vali@itrun.com")
{
    FirstName = "Vali",
    LastName = "Kowalski",
    Email = "alexkowalski@gmail.com",
};
Console.WriteLine($"User name is {ali.FirstName} last name is {ali.LastName}, age is {ali.Age}");


Console.WriteLine("Finished");
return;

(string name, int) GetUserInformation(Tuple<string, string, int> user)
{
    return (user.Item1, user.Item3);
}

enum WeekDays
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}

[Flags]
enum Permission
{
    None = 0,
    Read = 1,
    Create = 2,
    Modify = 4,
    Delete = 8,
    Test  = 64
}