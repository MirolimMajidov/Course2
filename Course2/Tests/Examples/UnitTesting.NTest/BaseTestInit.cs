using NUnit.Framework;

namespace UnitTesting.NTest;


public abstract class BaseTestInit
{
    // [SetUpFixture]
    // public static void ClassInitialize()
    // {
    // }


    [SetUp]
    public void TestInitialize()
    {
    }

    [TearDown]
    public void TestCleanup()
    {

    }

    //[ClassCleanup]
    //public static void ClassCleanup()
    //{
    //}
}
