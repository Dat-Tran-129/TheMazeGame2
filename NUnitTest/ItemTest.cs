using TheMazeGame2;

namespace NUnitTests;

public class ItemTest
{
    Item shovel;
    Item sword;
    
    [SetUp]
    public void Setup()
    {
        shovel = new Item(new string[] {"shovel"},"a shovel", "This is a shovel");
        sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
    }

    [Test]
    public void TestItemIdentifiable()
    {
        var result = shovel.AreYou("sword");
        Assert.IsFalse(result); 

        var result2 = shovel.AreYou("shovel");
        Assert.IsTrue(result2);

    }

    [Test]
    public void TestShortDescription()
    {
        Assert.AreEqual(shovel.ShortDescription, "a shovel shovel"); 
        Assert.AreNotEqual(shovel.ShortDescription, "This is a shovel"); 
    }

    [Test]
    public void TestFullDescription()
    {
        Assert.AreEqual(sword.FullDescription, "This is a sword"); 
        Assert.AreNotEqual(sword.FullDescription, "a shovel sword");

    }
}