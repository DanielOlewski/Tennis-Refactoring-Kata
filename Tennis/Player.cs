using System;

namespace Tennis
{
	internal class Player
	{
		public string Name { get; }

		public Player(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException();
			}

			Name = name;
		}

		public bool HasSameNameAs(Player other)
		{
			return other != null && Name == other.Name;
		}
	}
}