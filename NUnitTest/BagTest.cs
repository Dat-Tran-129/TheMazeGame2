using TheMazeGame2;

namespace NUnitTests;

public class BagTest
{
    Bag bag, bag1;
    Item shovel, sword, gem, paper; 

    [SetUp]
    public void Setup()
    {
        bag = new Bag(new string[] { "bag" }, "a bag", "This is a bag");
        bag1 = new Bag(new string[] { "bag1" }, "a bag1", "This is a bag1");
        
        shovel = new Item(new string[] {"shovel"},"a shovel", "This is a shovel");
        sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
        gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        paper = new Item(new string[] { "paper" }, "a paper", "This is a paper");
        
        bag.Inventory.Put(shovel);
        bag.Inventory.Put(sword);
        bag1.Inventory.Put(gem);
        bag1.Inventory.Put(paper);
    }
    
    [Test]
    public void TestBagLocatesItems()
    {
        Assert.AreEqual(bag.Locate(sword.FirstID), sword);
        Assert.AreNotEqual(bag1.Locate(shovel.FirstID), shovel);
    }
    
    [Test]
    public void TestBagLocateItself()
    {
        Assert.AreEqual(bag.Locate(bag.FirstID), bag);
    }
    

    [Test]
    public void TestBagLocateNothing()
    {
        Assert.AreEqual(bag.Locate(gem.FirstID), null);
    }

    [Test]
    public void TestBagFullDesc()
    {
        Assert.AreEqual(bag.FullDescription, "a bag, containing:\na shovel shovel\na sword sword\n");
    }

    [Test]
    public void TestBagInBag()
    {
        bag.Inventory.Put(bag1);
        Assert.AreEqual(bag.Locate(bag1.FirstID), bag1);
        Assert.AreEqual(bag.Locate(sword.FirstID), sword);
        Assert.AreNotEqual(bag.Locate(gem.FirstID), gem);
        
        Assert.AreEqual(bag.FullDescription, "a bag, containing:\na shovel shovel\na sword sword\na bag1 bag1\n");
        Assert.AreEqual(bag1.FullDescription, "a bag1, containing:\na gem gem\na paper paper\n");
    }

}