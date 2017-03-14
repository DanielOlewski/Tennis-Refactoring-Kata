using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	public class RawScoreCounting
	{
		[Test]
		public void P1PointCounted()
		{
			var counter = new RawScore();

			counter.Player1Scores();

			counter.Player1Score.ShouldEqual<uint>(1);
			counter.Player2Score.ShouldEqual<uint>(0);
		}

		[Test]
		public void P1ScoresTwice()
		{
			var counter = new RawScore();

			counter.Player1Scores();
			counter.Player1Scores();

			counter.Player1Score.ShouldEqual<uint>(2);
			counter.Player2Score.ShouldEqual<uint>(0);
		}

		[Test]
		public void PlayersScoreMultipleTimes()
		{
			var counter = new RawScore();

			counter.Player1Scores();
			counter.Player1Scores();
			counter.Player2Scores();
			counter.Player1Scores();


			counter.Player1Score.ShouldEqual<uint>(3);
			counter.Player2Score.ShouldEqual<uint>(1);
		}

		[Test]
		public void MidgamePointScored()
		{
			var counter = new RawScore(2, 5);

			counter.Player1Scores();

			counter.Player1Score.ShouldEqual<uint>(3);
			counter.Player2Score.ShouldEqual<uint>(5);
		}
	}

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
	}
}