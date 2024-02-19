using TheMazeGame2;

namespace NUnitTests;

public class PlayerTest
{
    Player player;
    Item shovel, sword;
    
    [SetUp]
    public void Setup()
    {
        player = new Player("Pekhoc", "Deptraivcl");
        shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        sword = new Item(new string[] { "sword" }, "a sword", "This is a Sword");
    }

    [Test]
    public void TestPlayerIdentifiable()
    {
        Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));
    }

    [Test]
    public void TestPlayerLocateItems()
    {
        var result = false;
        player.Inventory.Put(sword);
        var itemsLocated = player.Locate("sword");
        if (sword == itemsLocated)
        {
            result = true;
        }
        Assert.IsTrue(result);
    }

    [Test]
    public void TestPlayerLocateItself()
    {
        var me = player.Locate("me");
        var inv = player.Locate("inventory");
        var result = false;

        if (me == player || inv == player)
        {
            result = true;
        }
        Assert.IsTrue(result);
    }

    [Test]
    public void TestPlayerLocateNothing()
    {
        var me = player.Locate("Hi");
        Assert.IsNull(me);
    }

    [Test]
    public void TestPlayerFullDescription()
    {
        player.Inventory.Put(sword);
        player.Inventory.Put(shovel);
        string expected = "Pekhoc, you are carrying:\na sword sword\na shovel shovel\n";
        Assert.AreEqual(player.FullDescription, expected);
    }
}
