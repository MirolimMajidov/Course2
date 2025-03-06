
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

using MyFirstApp.Models;

var ali = new User(1)
{
    FirstName = "Alex",
    LastName = "Kowalski",
    Email = "alexkowalski@gmail.com",
};
ali.DoWork();
var id = ali.Id;
ali.Age = 45;

var userDTO = new UserDTO();
userDTO.Id = userDTO.Id;
userDTO.FirstName = ali.FirstName;
userDTO.Email = ali.Email;


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