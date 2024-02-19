﻿using TheMazeGame2;

namespace NUnitTests;

public class TestInventory
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
    public void TestFindItem()
    {
        Inventory i = new Inventory();
        i.Put(shovel);
        Assert.IsTrue(i.HasItem(shovel.FirstID));
    }

    [Test]
    public void TestNoFindItem()
    {
        Inventory i = new Inventory();
        i.Put(shovel);
        Assert.IsFalse(i.HasItem(sword.FirstID));
    }

    [Test]
    public void TestFetchItems()
    {
        Inventory i = new Inventory();
        i.Put(shovel);
        Item fetchItem = i.Fetch(shovel.FirstID);
        Assert.IsTrue(fetchItem == shovel);
        Assert.IsTrue(i.HasItem(shovel.FirstID));
    }

    [Test]
    public void TestTakenItem()
    {
        Inventory i = new Inventory();
        i.Put(shovel);
        i.Take(shovel.FirstID);
        Assert.IsFalse(i.HasItem(shovel.FirstID));
    }

    [Test]
    public void TestItemList()
    {
        Inventory i = new Inventory();
        i.Put(shovel);
        i.Put(sword);
        Assert.IsTrue(i.HasItem(shovel.FirstID));
        Assert.IsTrue(i.HasItem(sword.FirstID));
        string expctOutput = "a shovel shovel\n" + "a sword sword\n";
        Assert.AreEqual(i.ItemList, expctOutput);
    }

}