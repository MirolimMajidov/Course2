using NUnit.Framework;

namespace UnitTesting.NTest;


public class TestInit
{
    [OneTimeSetUp]
    public static void AssemblyInitialize(TestContext testContext)
    {
    }

    [OneTimeTearDown]
    public static void AssemblyCleanup()
    {
    }
}
