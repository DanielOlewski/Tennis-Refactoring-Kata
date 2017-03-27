namespace Tennis
{
	public class RawScore
	{
		public RawScore(uint p1BallsWon, uint p2BallsWon)
		{
			Player1BallsWon = p1BallsWon;
			Player2BallsWon = p2BallsWon;
		}

		public RawScore() : this (0, 0)
		{
		}

		public void Player1Scores()
		{
			Player1BallsWon++;
		}

		public void Player2Scores()
		{
			Player2BallsWon++;
		}

		public uint Player1BallsWon { get; private set;  }
		public uint Player2BallsWon { get; private set; }


		public bool PlayerScoresAreEqual => Player1BallsWon == Player2BallsWon;
		public bool EitherPlayerWonAtLeast4Balls => Player1BallsWon >= 4 || Player2BallsWon >= 4;
	}
}