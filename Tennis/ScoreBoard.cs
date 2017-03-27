using System;

namespace Tennis
{
	internal static class ScoreBoard
	{
		public delegate string NamingRule(RawScore rawScore, Player player1, Player player2);

		public static string Render(RawScore rawScore, Player player1, Player player2, NamingRule[] rules)
		{
			if (player1 == null || player2 == null)
			{
				throw new ArgumentException("Player names must be provided!");
			}

			if (player1.HasSameNameAs(player2))
			{
				throw new ArgumentException("Player names must be different!");
			}

			return RunRules(rawScore, player1, player2, rules);
		}

		private static string RunRules(RawScore rawScore, Player player1, Player player2, NamingRule[] rules)
		{
			foreach (var namingRule in rules)
			{
				var namedScore = namingRule(rawScore, player1, player2);
				if (namedScore != null)
					return namedScore;
			}

			return "<Unknown score>";
		}
	}
}