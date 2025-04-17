using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly User[] Users =
    [
        new User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Email = "John@test.tj"
        },
        new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Ali",
            LastName = "Vali",
            Age = 10,
            Email = "Ali@test.tj"
        }
    ];

    [HttpGet(Name = "GetAll")]
    public IEnumerable<User> GetAll()
    {
        return Users;
    }
}