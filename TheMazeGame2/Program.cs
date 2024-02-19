namespace TheMazeGame2;

public class Program
{
    static void LookCommandExe(Command l, string input, Player player)
        {
            Console.WriteLine(l.Execute(player, input.Split()));
        }

        static void Main(string[] args)
        {
            string name, desc;

            //Message greetings
            Message greetings;
            greetings = new Message("Welcome to TheMazeGame2\n\nHere are some helpful command:\n-look\n-move\n");
            greetings.Print();
            Console.WriteLine("Press 'Enter' to continue...");
            Console.ReadLine();

            //Setup player
            Console.Write("Setting up player:\nPlayer Name: ");
            name = Console.ReadLine();
            Console.Write("Player Description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);
            Console.Write("\n");

            //Setup list of items
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a bronze shovel");
            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a silver sword");
            Item gem = new Item(new string[] { "gem" }, "a gem", "A bright red gem");
            Item monitor = new Item(new string[] { "monitor" }, "a monitor", "This is 2k 240hz monitor");
            Item computer = new Item(new string[] { "computer" }, "a computer", "This is a computer");
            Item phone = new Item(new string[] { "phone" }, "a phone", "This is Bphone15 superultraproMAX");
            Item tv = new Item(new string[] { "tv" }, "a tv", "This is a LG OLED evo 8K 88inch TV");
            Item pan = new Item(new string[] { "pan" }, "a pan", "This is a steel pan");
            
            //Setup Location
            Location myroom = new Location("My Room", "My room");
            player.Location = myroom; //set up player initial location

            Location gamingroom = new Location("Gaming room", "Gaming room");
            Path MyroomToGamingroom = new Path(new string[] { "north" }, "Door", "Travel through door", myroom, gamingroom);
            Path GamingroomToMyroom = new Path(new string[] { "south" }, "Door", "Travel through door", gamingroom, myroom);
            myroom.AddPath(MyroomToGamingroom);
            gamingroom.AddPath(GamingroomToMyroom);

            Location livingroom = new Location("Living room", "Living room");
            Path MyroomToiLivingroom = new Path(new string[] { "east" }, "Door", "Travel through door", myroom, livingroom);
            Path LivingroomToMyroom = new Path(new string[] { "west" }, "Door", "Travel through door", livingroom, myroom);
            myroom.AddPath(MyroomToiLivingroom);
            livingroom.AddPath(LivingroomToMyroom);

            Location kitchen = new Location("Kitchen", "Kitchen");
            Path MyroomToKitchen = new Path(new string[] { "south" }, "Door", "Travel through door", myroom, kitchen);
            Path KitchenToMyroom = new Path(new string[] { "north" }, "Door", "Travel through door", kitchen, myroom);
            myroom.AddPath(MyroomToKitchen);
            kitchen.AddPath(KitchenToMyroom);
            
            //Setup inventory
            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);
            
            //Location item
            myroom.Inventory.Put(phone);
            gamingroom.Inventory.Put(monitor);
            gamingroom.Inventory.Put(computer);
            livingroom.Inventory.Put(tv);
            kitchen.Inventory.Put(pan);

            //Setup input command
            string _input;
            Command c = new CommandProcessor();
            Console.WriteLine(c.Execute(player, new string[] { "look" }));
            while (true)
            {
                Console.Write("Command: ");
                _input = Console.ReadLine();
                if (_input.ToLower() != "quit")
                {
                    Console.WriteLine(c.Execute(player, _input.Split()));
                } 
                else
                {
                    Console.WriteLine("Game Over --- Bye");
                    Console.ReadKey();
                    break;
                }
            }
        }
}

