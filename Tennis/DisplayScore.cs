using System;

namespace Tennis
{
	internal static class DisplayScore
	{
		public static string Render(RawScore rawScore, string player1Name, string player2Name)
		{
			return rawScore.PlayerScoresAreEqual
				? NameEqualScore(rawScore)
				: (rawScore.WinBy2Naming ? NameWinOrAdvantageScore(rawScore, player1Name, player2Name) : NameLowScore(rawScore));
		}

		private static string NameLowScore(RawScore rawScore)
		{
			return LowScoreToTennisScoreName(rawScore.Player1Score) + "-" + LowScoreToTennisScoreName(rawScore.Player2Score);
		}

		private static string NameWinOrAdvantageScore(RawScore rawScore, string player1Name, string player2Name)
		{
			var scoreDifference = (int) rawScore.Player1Score - (int) rawScore.Player2Score;
			var playerAhead = scoreDifference > 0 ? player1Name : player2Name;
			var winOrAdvantageString = Math.Abs(scoreDifference) == 1 ? "Advantage " : "Win for ";

			return winOrAdvantageString + playerAhead;
		}

		private static string NameEqualScore(RawScore rawScore)
		{
			return rawScore.Player1Score > 2 ? "Deuce" : LowScoreToTennisScoreName(rawScore.Player1Score) + "-All";
		}

		private static string LowScoreToTennisScoreName(uint lowScore)
		{
			return new[] { "Love", "Fifteen", "Thirty", "Forty" }[lowScore];
		}
	}
}