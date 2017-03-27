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

			counter.Player1BallsWon.ShouldEqual<uint>(1);
			counter.Player2BallsWon.ShouldEqual<uint>(0);
		}

		[Test]
		public void P1ScoresTwice()
		{
			var counter = new RawScore();

			counter.Player1Scores();
			counter.Player1Scores();

			counter.Player1BallsWon.ShouldEqual<uint>(2);
			counter.Player2BallsWon.ShouldEqual<uint>(0);
		}

		[Test]
		public void PlayersScoreMultipleTimes()
		{
			var counter = new RawScore();

			counter.Player1Scores();
			counter.Player1Scores();
			counter.Player2Scores();
			counter.Player1Scores();


			counter.Player1BallsWon.ShouldEqual<uint>(3);
			counter.Player2BallsWon.ShouldEqual<uint>(1);
		}

		[Test]
		public void MidgamePointScored()
		{
			var counter = new RawScore(2, 5);

			counter.Player1Scores();

			counter.Player1BallsWon.ShouldEqual<uint>(3);
			counter.Player2BallsWon.ShouldEqual<uint>(5);
		}

		
		// below new UTs added for step 2

		[Test]
		public void EqualScoreDetectedWhenTrue()
		{
			var counter = new RawScore(2, 2);

			counter.PlayerScoresAreEqual.ShouldBeTrue();
		}

		[Test]
		public void EqualScoreDetectedAfterIncrement()
		{
			var counter = new RawScore(2, 1);

			counter.Player2Scores();

			counter.PlayerScoresAreEqual.ShouldBeTrue();
		}

		[Test]
		public void PlayerScoresArentSameWhenBallsWonDifferent()
		{
			var counter = new RawScore(2, 4);

			counter.PlayerScoresAreEqual.ShouldBeFalse();
		}

		[Test]
		public void AtLeast4NotTrueWithLowScores()
		{
			var counter = new RawScore(2, 1);

			counter.EitherPlayerWonAtLeast4Balls.ShouldBeFalse();
		}

		[Test]
		public void P1With4PlusScoreDetectedAsAtLeast4()
		{
			var counter = new RawScore(4, 1);

			counter.EitherPlayerWonAtLeast4Balls.ShouldBeTrue();
		}

		[Test]
		public void P2With4PlusScoreDetectedAsAtLeast4()
		{
			var counter = new RawScore(0, 4);

			counter.EitherPlayerWonAtLeast4Balls.ShouldBeTrue();
		}

		[Test]
		public void BothPlayersWith4PlusScoreDetectedAsAtLeast4()
		{
			var counter = new RawScore(5, 6);

			counter.EitherPlayerWonAtLeast4Balls.ShouldBeTrue();
		}
	}
}