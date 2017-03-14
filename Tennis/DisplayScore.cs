namespace Tennis
{
	internal static class DisplayScore
	{
		public static string Render(RawScore rawScore, string player1Name, string player2Name)
		{
			return rawScore.PlayerScoresAreEqual
				? WhenEqualScore(rawScore)
				: (rawScore.WinBy2Mode ? WhenWinBy2Mode(rawScore, player1Name, player2Name) : WhenNormalScore(rawScore));
		}

		private static string WhenNormalScore(RawScore rawScore)
		{
			var displayScore = "";
			for (var i = 1; i < 3; i++)
			{
				uint tempScore;
				if (i == 1)
				{
					tempScore = rawScore.Player1Score;
				}
				else
				{
					displayScore += "-";
					tempScore = rawScore.Player2Score;
				}

				switch (tempScore)
				{
					case 0:
						displayScore += "Love";
						break;
					case 1:
						displayScore += "Fifteen";
						break;
					case 2:
						displayScore += "Thirty";
						break;
					case 3:
						displayScore += "Forty";
						break;
				}
			}
			return displayScore;
		}

		private static string WhenWinBy2Mode(RawScore rawScore, string player1Name, string player2Name)
		{
			string displayScore;
			var minusResult = (int) rawScore.Player1Score - (int) rawScore.Player2Score;
			switch (minusResult)
			{
				case 1:
					displayScore = $"Advantage {player1Name}";
					break;
				case -1:
					displayScore = $"Advantage {player2Name}";
					break;
				default:
					displayScore = minusResult >= 2 ? $"Win for {player1Name}" : $"Win for {player2Name}";
					break;
			}
			return displayScore;
		}

		private static string WhenEqualScore(RawScore rawScore)
		{
			string displayScore;
			switch (rawScore.Player1Score)
			{
				case 0:
					displayScore = "Love-All";
					break;
				case 1:
					displayScore = "Fifteen-All";
					break;
				case 2:
					displayScore = "Thirty-All";
					break;
				default:
					displayScore = "Deuce";
					break;
			}
			return displayScore;
		}
	}
}