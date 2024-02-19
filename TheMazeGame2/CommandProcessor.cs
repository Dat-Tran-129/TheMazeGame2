namespace TheMazeGame2;

public class CommandProcessor : Command
	{
		List<Command> _commands;

		public CommandProcessor() : base(new string[] { "command" })
		{
			_commands = new List<Command>();
			_commands.Add(new LookCommand());
			_commands.Add(new MoveCommand());
		}

		public override string Execute(Player p, string[] text)
		{
			foreach (Command cmd in _commands)
			{
				if (cmd.AreYou(text[0].ToLower()))
				{
					return cmd.Execute(p, text);
				}
			}
			return "Error in command input.";
		}
	}