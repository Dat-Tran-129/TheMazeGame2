using TheMazeGame2;

namespace NUnitTests;

public class IdentifiableObjectTest
{
    private IdentifiableObject _testObject;
    private IdentifiableObject _testObject1;
    
    [SetUp]
    public void Setup()
    {
        _testObject = new IdentifiableObject(new string[] { "fred", "bob" });
        _testObject1 = new IdentifiableObject(new string[] { });
    }

    [Test]
    public void TestAreYou()
    {
        Assert.IsTrue(_testObject.AreYou("fred"));
        Assert.IsTrue(_testObject.AreYou("bob"));
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.IsFalse(_testObject.AreYou("wilma"));
        Assert.IsFalse(_testObject.AreYou("boby"));
    }

    [Test]
    public void TestCaseSensitive()
    {
        Assert.IsTrue(_testObject.AreYou("FRED"));
        Assert.IsTrue(_testObject.AreYou("bOB"));
    }

    [Test]
    public void TestFirstID()
    {
        Assert.AreEqual("fred", _testObject.FirstID);
    }

    [Test]
    public void TestFirstIdWithNoID()
    {
        Assert.AreEqual("", _testObject1.FirstID);
    }

    [Test]
    public void TestAddID()
    {
        _testObject.AddIdentifier("WILMA");
        Assert.IsTrue(_testObject.AreYou("WILMA"));
        Assert.IsTrue(_testObject.AreYou("fred"));
        Assert.IsTrue(_testObject.AreYou("bob"));
    }
}
