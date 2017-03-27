using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	internal class NamingTennisScores
	{
		private readonly Player P1 = new Player("a");
		private readonly Player P2 = new Player("B");

		[Test]
		public void EqualHighScoreNamedDeuce()
		{
			var namedScore = TennisScoreNaming.NameEqualScore(new RawScore(5, 5), P1, P2);

			namedScore.ShouldEqual("Deuce");
		}

		[Test]
		public void EqualLowScoreNamedCorrectly()
		{
			var namedScore = TennisScoreNaming.NameEqualScore(new RawScore(1, 1), P1, P2);

			namedScore.ShouldEqual("Fifteen-All");
		}

		[Test]
		public void EqualScoreRuleSkipsWhenScoresDifferent()
		{
			var namedScore = TennisScoreNaming.NameEqualScore(new RawScore(1, 2), P1, P2);

			namedScore.ShouldBeNull();
		}

		[Test]
		public void LowScoreRuleSkipsWhenScoreHigh()
		{
			var namedScore = TennisScoreNaming.NameLowScore(new RawScore(3, 4), P1, P2);

			namedScore.ShouldBeNull();
		}

		[Test]
		public void LowScore_15_30()
		{
			var namedScore = TennisScoreNaming.NameLowScore(new RawScore(1, 2), P1, P2);

			namedScore.ShouldEqual("Fifteen-Thirty");
		}

		[Test]
		public void LowScore_0_40()
		{
			var namedScore = TennisScoreNaming.NameLowScore(new RawScore(0, 3), P1, P2);

			namedScore.ShouldEqual("Love-Forty");
		}

		[Test]
		public void AdvantageRuleSkipsWhenLowScores()
		{
			var namedScore = TennisScoreNaming.NameWinOrAdvantageScore(new RawScore(1, 3), P1, P2);

			namedScore.ShouldBeNull();
		}

		[Test]
		public void AdvantageP1()
		{
			var namedScore = TennisScoreNaming.NameWinOrAdvantageScore(new RawScore(4, 3), P1, P2);

			namedScore.ShouldEqual("Advantage a");
		}

		[Test]
		public void WinP1()
		{
			var namedScore = TennisScoreNaming.NameWinOrAdvantageScore(new RawScore(5, 3), P1, P2);

			namedScore.ShouldEqual("Win for a");
		}

		[Test]
		public void WinP2()
		{
			var namedScore = TennisScoreNaming.NameWinOrAdvantageScore(new RawScore(5, 7), P1, P2);

			namedScore.ShouldEqual("Win for B");
		}

		[Test]
		public void AdvantageP2()
		{
			var namedScore = TennisScoreNaming.NameWinOrAdvantageScore(new RawScore(5, 6), P1, P2);

			namedScore.ShouldEqual("Advantage B");
		}
	}
}
