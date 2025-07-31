namespace FirstTestProject;

#if DEBUG
public class Tests
{
    [SetUp]
    public void Setup()
    {
        Console.WriteLine("Setup");
    }
    
    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("TearDown");
    }

    [Test]
    public void Test_ShouldPass()
    {
        var a = 5;
        var b = 10;
        var sum = a + b;
        Assert.That(sum, Is.EqualTo(15), "Both should be same");
    }

    [Test]
    public void Test_ShouldFail()
    {
        var a = 5;
        var b = 10;
        var sum = a + b;
        Assert.That(sum, Is.EqualTo(10), "Both should be same");
    }
}
#endif