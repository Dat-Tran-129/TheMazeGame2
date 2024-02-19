using TheMazeGame2;

namespace NUnitTests;


public class LookCommandTest
{
    Command look;
    Player player, player1;
    Bag bag;
    Item shovel, sword, gem, paper;
    

    [SetUp]
    public void Setup()
    {
        look = new LookCommand();
        
        player = new Player("Pekhoc", "Deptraivcl"); //Player with bag
        player1 = new Player("Pekhoc1", "Deptraivcll"); //Player with no bag
        
        bag = new Bag(new string[] { "bag" }, $"Pekhoc's bag", $"This is {player.FirstID} bag");
        
        shovel = new Item(new string[] {"shovel"},"a shovel", "This is a shovel");
        sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
        gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        paper = new Item(new string[] { "paper" }, "a paper", "This is a paper");
        
        player.Inventory.Put(bag);
    }

    [Test]
    public void TestLookAtMe()
    {
        Assert.AreEqual( $"{player.Name}, you are carrying:\n{player.Inventory.ItemList}", 
            look.Execute(player, new string[] { "look", "at", "inventory" }));
    }

    [Test]
    public void TestLookAtGem()
    {
        player.Inventory.Put(gem);
        string Output = look.Execute(player, new string[] { "look", "at", "gem" });
        string exp = $"{gem.FullDescription}";
        Assert.AreEqual(exp, Output);
    }

    [Test] 
    public void TestLookAtUnk()
    {
        Assert.AreEqual($"I cannot find the gem", 
            look.Execute(player, new string[] { "look", "at", "gem" }));
    }

    [Test]
    public void TestLookAtGemInMe()
    {
        player.Inventory.Put(gem);
        Assert.AreEqual($"{gem.FullDescription}", 
            look.Execute(player, new string[] { "look", "at", "gem", "in", "me" }));
    }

    [Test]
    public void TestLookAtGemInBag()
    {
        bag.Inventory.Put(gem);
        Assert.AreEqual($"{gem.FullDescription}", 
            look.Execute(player, new string[] { "look", "at", "gem", "in", $"bag" }));
    }

    [Test]
    public void TestLookAtNoGemInBag()
    {
        Assert.AreEqual("I cannot find the gem", 
            look.Execute(player, new string[] { "look", "at", "gem", "in", $"bag" }));
    }

    [Test] 
    public void TestLookAtGemInNoBag()
    {
        bag.Inventory.Put(gem);
        player1.Inventory.Put(bag);
        Assert.AreEqual("I cannot find the gem",
            look.Execute(player1, new string[] { "look", "at", "gem", "in", $"{player.FirstID}" }));
    }

    [Test]
    public void TestInvalidLook()
    {
        Assert.AreEqual(look.Execute(player1, new string[] { "look", "around" }), "Error in look input.");
        Assert.AreEqual(look.Execute(player1, new string[] { "find", "gem" }), "Error in look input.");
    }
}