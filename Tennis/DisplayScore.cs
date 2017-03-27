using System;

namespace Tennis
{
	internal static class DisplayScore
	{
		public delegate string NamingRule(RawScore rawScore, string player1Name, string player2Name);

		public static string Render(RawScore rawScore, string player1Name, string player2Name)
		{
			var namingRuleSequence = new NamingRule[]
			{
				NameEqualScore,
				NameWinOrAdvantageScore,
				NameLowScore,
			};
			return Render(rawScore, player1Name, player2Name, namingRuleSequence);
		}


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

		private static string NameLowScore(RawScore rawScore, string player1Name, string player2Name)
		{
			return LowScoreToTennisScoreName(rawScore.Player1BallsWon) + "-" + LowScoreToTennisScoreName(rawScore.Player2BallsWon);
		}

		private static string NameWinOrAdvantageScore(RawScore rawScore, string player1Name, string player2Name)
		{
			if (!rawScore.EitherPlayerWonAtLeast4Balls)
				return null;
			var scoreDifference = (int) rawScore.Player1BallsWon - (int) rawScore.Player2BallsWon;
			var playerAhead = scoreDifference > 0 ? player1Name : player2Name;
			var winOrAdvantageString = Math.Abs(scoreDifference) == 1 ? "Advantage " : "Win for ";

			return winOrAdvantageString + playerAhead;
		}

		private static string NameEqualScore(RawScore rawScore, string player1Name, string player2Name)
		{
			return rawScore.PlayerScoresAreEqual ? (rawScore.Player1BallsWon > 2 ? "Deuce" : LowScoreToTennisScoreName(rawScore.Player1BallsWon) + "-All") : null;
		}

		private static string LowScoreToTennisScoreName(uint lowScore)
		{
			return new[] { "Love", "Fifteen", "Thirty", "Forty" }[lowScore];
		}
	}
}