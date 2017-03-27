using System;
using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	public class RenderingDisplayScore
	{
		private readonly Player P1 = new Player("a");
		private readonly Player P2 = new Player("B");

		[Test]
		public void P1Required()
		{
			Action action = () => ScoreBoard.Render(new RawScore(1, 1), null, P2, null);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void P2Required()
		{
			Action action = () => ScoreBoard.Render(new RawScore(1, 1), P1, null, null);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void PlayerNamesMustBeDifferent()
		{
			Action action = () => ScoreBoard.Render(new RawScore(1, 1), P1, P1, null);

			action.ShouldThrow<ArgumentException>();
		}


		[Test]
		public void SingleRuleEvaluated()
		{
			ScoreBoard.NamingRule r1 = (rawScore, p1, p2) => "r1";

			var renderedScore = ScoreBoard.Render(new RawScore(0, 1), P1, P2, new [] { r1 });

			renderedScore.ShouldEqual("r1");
		}

		[Test]
		public void WhenFirstRuleHitsNoOtherRulesExecuted()
		{
			var namingRules = new ScoreBoard.NamingRule[]
			{
				(rawScore, p1, p2) => "r1",
				(rawScore, p1, p2) => "r2"
			};
			var renderedScore = ScoreBoard.Render(new RawScore(0, 1), P1, P2, namingRules);

			renderedScore.ShouldNotEqual("r2");
		}

		[Test]
		public void WhenFirstRuleNotHitsOtherRulesExecuted()
		{
			var namingRules = new ScoreBoard.NamingRule[]
			{
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => "r2"
			};
			var renderedScore = ScoreBoard.Render(new RawScore(0, 1), P1, P2, namingRules);

			renderedScore.ShouldEqual("r2");
		}

		[Test]
		public void WhenFirstRuleNotHitsOtherRulesExecuted2()
		{
			var namingRules = new ScoreBoard.NamingRule[]
			{
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => "r2"
			};
			var renderedScore = ScoreBoard.Render(new RawScore(0, 1), P1, P2, namingRules);

			renderedScore.ShouldEqual("r2");
		}

		[Test]
		public void WhenNoRuleHitsScoreIsUnknown()
		{
			var namingRules = new ScoreBoard.NamingRule[]
			{
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => null,
			};
			var renderedScore = ScoreBoard.Render(new RawScore(0, 1), P1, P2, namingRules);

			renderedScore.ShouldEqual("<Unknown score>");
		}

	}
}
