using System;

namespace Tennis
{
	internal static class DisplayScore
	{
		public delegate string NamingRule(RawScore rawScore, string player1Name, string player2Name);

		public static string Render(RawScore rawScore, string player1Name, string player2Name, NamingRule[] rules)
		{
			if (string.IsNullOrEmpty(player1Name) || string.IsNullOrEmpty(player2Name))
			{
				throw new ArgumentException("Player names must be provided!");
			}

			if (player1Name == player2Name)
			{
				throw new ArgumentException("Player names must be different!");
			}

			return RunRules(rawScore, player1Name, player2Name, rules);
		}

		private static string RunRules(RawScore rawScore, string player1Name, string player2Name, NamingRule[] rules)
		{
			foreach (var namingRule in rules)
			{
				var namedScore = namingRule(rawScore, player1Name, player2Name);
				if (namedScore != null)
					return namedScore;
			}

			return "<Unknown score>";
		}
	}
}