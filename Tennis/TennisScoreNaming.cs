using System;

namespace Tennis
{
	internal static class TennisScoreNaming
	{
		public static ScoreBoard.NamingRule[] Rules =>
			new ScoreBoard.NamingRule[]
			{
				NameEqualScore, NameWinOrAdvantageScore, NameLowScore,
			};

		public static string NameLowScore(RawScore rawScore, Player player1, Player player2)
		{
			return rawScore.EitherPlayerWonAtLeast4Balls ? null : LowScoreToTennisScoreName(rawScore.Player1BallsWon) + "-" + LowScoreToTennisScoreName(rawScore.Player2BallsWon);
		}

		public static string NameWinOrAdvantageScore(RawScore rawScore, Player player1, Player player2)
		{
			if (!rawScore.EitherPlayerWonAtLeast4Balls)
				return null;
			var scoreDifference = (int) rawScore.Player1BallsWon - (int) rawScore.Player2BallsWon;
			var playerAhead = scoreDifference > 0 ? player1.Name : player2.Name;
			var winOrAdvantageString = Math.Abs(scoreDifference) == 1 ? "Advantage " : "Win for ";

			return winOrAdvantageString + playerAhead;
		}

		public static string NameEqualScore(RawScore rawScore, Player player1, Player player2)
		{
			return rawScore.PlayerScoresAreEqual ? (rawScore.Player1BallsWon > 2 ? "Deuce" : LowScoreToTennisScoreName(rawScore.Player1BallsWon) + "-All") : null;
		}

		private static string LowScoreToTennisScoreName(uint lowScore)
		{
			return new[] { "Love", "Fifteen", "Thirty", "Forty" }[lowScore];
		}
	}
}