namespace Tennis
{
	public class RawScore
	{
		public RawScore(uint p1score, uint p2score)
		{
			Player1Score = p1score;
			Player2Score = p2score;
		}

		public RawScore() : this (0, 0)
		{
		}

		public void Player1Scores()
		{
			Player1Score++;
		}

		public void Player2Scores()
		{
			Player2Score++;
		}

		public uint Player1Score { get; private set;  }
		public uint Player2Score { get; private set; }


		public bool PlayerScoresAreEqual => Player1Score == Player2Score;
		public bool WinBy2Mode => Player1Score >= 4 || Player2Score >= 4;
	}
}