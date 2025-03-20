
using MyFirstApp.Models;

User.UserCreated += UserCreatedHandler1;
User.UserCreated += UserCreatedHandler2;

var user = new User
{
    FirstName = "Ali",
    LastName = "Valievich",
    OnStartingWork = UserWorking
};
user.DoWork();
user.DoWork();
user.OnStartingWork -= UserWorking;

user.OnStartingWork += (sender, args) =>
{
    Console.WriteLine("User working");
};
user.DoWork();


Console.WriteLine("End");

void UserCreatedHandler1(object sender, EventArgs e)
{
    if(sender is User user)
        Console.WriteLine($"User created1: {user.FirstName}");
    
    Console.WriteLine("User created1");
}

void UserCreatedHandler2(object sender, DoWorkEventArgs e)
{
    Console.WriteLine($"User created1: {e.UserName}");
    Console.WriteLine("User created2");
}

void UserWorking(object sender, EventArgs e)
{
    Console.WriteLine("User working");
}