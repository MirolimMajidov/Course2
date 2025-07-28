namespace FirstTestProject;

public class UserTests
{
    [Test]
    public void User_OnlyFirstNameHasValue_FullNameShouldBeEqualToFirstName()
    {
        // Arrange
        var name = "Ali";
        var user = new User { FirstName = name, LastName = null };
        
        // Act
        var fullName = user.GetFullName();
        
        // Assert
        Assert.That(fullName, Is.EqualTo(name), "Full name should be equal to first name when last name is null.");
    }
    
    [Test]
    public void User_OnlyLastNameHasValue_FullNameShouldBeEqualToLastName()
    {
        // Arrange
        var name = "Esh";
        var user = new User { FirstName = null, LastName = name };
        
        // Act
        var fullName = user.GetFullName();
        
        // Assert
        Assert.That(fullName, Is.EqualTo(name));
    }
    
    [Test]
    public void User_BothPropertiesHasValue_FullNameShouldBeEqualToCombinationOfBothProperty()
    {
        // Arrange
        var firstName = "Jake";
        var name = "Esh";
        var user = new User { FirstName = firstName, LastName = name };
        
        // Act
        var fullName = user.GetFullName();
        
        // Assert
        var expectedFullName = $"{firstName} {name}";
        Assert.That(fullName, Is.EqualTo(expectedFullName));
    }
}