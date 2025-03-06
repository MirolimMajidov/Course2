namespace MyFirstApp.Models;

//public record UserDTO(int Id, string FirstName, string Email);
public record UserDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
}
