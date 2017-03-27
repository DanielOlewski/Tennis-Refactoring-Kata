using System;
using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	public class PlayingTennisGame
	{
		private const string P1Name = "a";
		private const string P2Name = "B";

		[Test]
		public void P1ScoringChangesTheScore()
		{
			var game = new TennisGame1(P1Name, P2Name);
			var scoreBeforePoint = game.Score;

			game.WonPoint(P1Name);

			game.Score.ShouldNotBeSameAs(scoreBeforePoint);
		}

		[Test]
		public void StartingScoreDefined()
		{
			var game = new TennisGame1(P1Name, P2Name);

			game.Score.ShouldNotBeNull();
		}


		[Test]
		public void P2ScoringChangesTheScore()
		{
			var game = new TennisGame1(P1Name, P2Name);
			var scoreBeforePoint = game.Score;

			game.WonPoint(P2Name);

			game.Score.ShouldNotBeSameAs(scoreBeforePoint);
		}

		[Test]
		public void UnknownPlayerScoringNotAllowed()
		{
			var game = new TennisGame1(P1Name, P2Name);

			Action action = () => game.WonPoint("some other player");

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void SamePlayerNamesNotAllowed()
		{
			Action action = () => new TennisGame1(P1Name, P1Name);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void InvalidP1NameNotAllowed()
		{
			Action action = () => new TennisGame1("", P2Name);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void InvalidP2NameNotAllowed()
		{
			Action action = () => new TennisGame1(P1Name, null);

			action.ShouldThrow<ArgumentException>();
		}
	}
}
