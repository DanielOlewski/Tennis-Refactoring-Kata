using System;
using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	public class ScoringTennis
	{
		[TestCase(0, 0, "Love-All")]
		[TestCase(1, 1, "Fifteen-All")]
		[TestCase(2, 2, "Thirty-All")]
		[TestCase(3, 3, "Deuce")]
		[TestCase(4, 4, "Deuce")]
		[TestCase(1, 0, "Fifteen-Love")]
		[TestCase(0, 1, "Love-Fifteen")]
		[TestCase(2, 0, "Thirty-Love")]
		[TestCase(0, 2, "Love-Thirty")]
		[TestCase(3, 0, "Forty-Love")]
		[TestCase(0, 3, "Love-Forty")]
		[TestCase(4, 0, "Win for player-A")]
		[TestCase(0, 4, "Win for player-B")]
		[TestCase(2, 1, "Thirty-Fifteen")]
		[TestCase(1, 2, "Fifteen-Thirty")]
		[TestCase(3, 1, "Forty-Fifteen")]
		[TestCase(1, 3, "Fifteen-Forty")]
		[TestCase(4, 1, "Win for player-A")]
		[TestCase(1, 4, "Win for player-B")]
		[TestCase(3, 2, "Forty-Thirty")]
		[TestCase(2, 3, "Thirty-Forty")]
		[TestCase(4, 2, "Win for player-A")]
		[TestCase(2, 4, "Win for player-B")]
		[TestCase(4, 3, "Advantage player-A")]
		[TestCase(3, 4, "Advantage player-B")]
		[TestCase(5, 4, "Advantage player-A")]
		[TestCase(4, 5, "Advantage player-B")]
		[TestCase(15, 14, "Advantage player-A")]
		[TestCase(14, 15, "Advantage player-B")]
		[TestCase(6, 4, "Win for player-A")]
		[TestCase(4, 6, "Win for player-B")]
		[TestCase(16, 14, "Win for player-A")]
		[TestCase(14, 16, "Win for player-B")]
		public void ShowsExpectedDisplayScore(int player1Score, int player2Score, string expectedDisplayScore)
        {
			var displayScore = DisplayScore.Render(new RawScore((uint)player1Score, (uint)player2Score), "player-A", "player-B");

			displayScore.ShouldEqual(expectedDisplayScore);
        }
    }

    [TestFixture]
    public class ExampleGameTennisTest
    {
        [Test]
        public void CheckGame1()
        {
            var game = new TennisGame1("player-A", "player-B"); 
            string[] ballWonSequence = { "player-A", "player-A", "player-B", "player-B", "player-A", "player-A" };
            string[] expectedScores = { "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for player-A" };

            for (var i = 0; i < expectedScores.Length; i++)
            {
                game.WonPoint(ballWonSequence[i]);
                expectedScores[i].ShouldEqual(game.GetScore());
            }
        }
    }

}

