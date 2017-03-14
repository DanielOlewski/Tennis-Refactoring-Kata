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
}