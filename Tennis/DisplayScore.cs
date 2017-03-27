using System;

namespace Tennis
{
	internal static class DisplayScore
	{
		private delegate string NamingRule();

		public static string Render(RawScore rawScore, string player1Name, string player2Name)
		{
			var namingRuleSequence = new NamingRule[]
			{
				() => NameEqualScore(rawScore),
				() => NameWinOrAdvantageScore(rawScore, player1Name, player2Name),
				() => NameLowScore(rawScore),
			};
			return RunRules(namingRuleSequence);
		}

		private static string RunRules(NamingRule[] namingRuleSequence)
		{
			foreach (var namingRule in namingRuleSequence)
			{
				var namedScore = namingRule();
				if (namedScore != null)
					return namedScore;
			}

			return "<Unknown score>";
		}

		private static string NameLowScore(RawScore rawScore)
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

		private static string NameEqualScore(RawScore rawScore)
		{
			return rawScore.PlayerScoresAreEqual ? (rawScore.Player1BallsWon > 2 ? "Deuce" : LowScoreToTennisScoreName(rawScore.Player1BallsWon) + "-All") : null;
		}

		private static string LowScoreToTennisScoreName(uint lowScore)
		{
			return new[] { "Love", "Fifteen", "Thirty", "Forty" }[lowScore];
		}
	}
}