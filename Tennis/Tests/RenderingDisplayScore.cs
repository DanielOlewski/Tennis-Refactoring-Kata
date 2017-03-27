using System;
using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	public class RenderingDisplayScore
	{
		private const string P1Name = "a";
		private const string P2Name = "B";

		[Test]
		public void P1Required()
		{
			Action action = () => DisplayScore.Render(new RawScore(1, 1), null, P2Name, null);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void P2Required()
		{
			Action action = () => DisplayScore.Render(new RawScore(1, 1), P1Name, "", null);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void PlayerNamesMustBeDifferent()
		{
			Action action = () => DisplayScore.Render(new RawScore(1, 1), P1Name, P1Name, null);

			action.ShouldThrow<ArgumentException>();
		}


		[Test]
		public void SingleRuleEvaluated()
		{
			DisplayScore.NamingRule r1 = (rawScore, p1, p2) => "r1";

			var renderedScore = DisplayScore.Render(new RawScore(0, 1), P1Name, P2Name, new [] { r1 });

			renderedScore.ShouldEqual("r1");
		}

		[Test]
		public void WhenFirstRuleHitsNoOtherRulesExecuted()
		{
			var namingRules = new DisplayScore.NamingRule[]
			{
				(rawScore, p1, p2) => "r1",
				(rawScore, p1, p2) => "r2"
			};
			var renderedScore = DisplayScore.Render(new RawScore(0, 1), P1Name, P2Name, namingRules);

			renderedScore.ShouldNotEqual("r2");
		}

		[Test]
		public void WhenFirstRuleNotHitsOtherRulesExecuted()
		{
			var namingRules = new DisplayScore.NamingRule[]
			{
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => "r2"
			};
			var renderedScore = DisplayScore.Render(new RawScore(0, 1), P1Name, P2Name, namingRules);

			renderedScore.ShouldEqual("r2");
		}

		[Test]
		public void WhenFirstRuleNotHitsOtherRulesExecuted2()
		{
			var namingRules = new DisplayScore.NamingRule[]
			{
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => "r2"
			};
			var renderedScore = DisplayScore.Render(new RawScore(0, 1), P1Name, P2Name, namingRules);

			renderedScore.ShouldEqual("r2");
		}

		[Test]
		public void WhenNoRuleHitsScoreIsUnknown()
		{
			var namingRules = new DisplayScore.NamingRule[]
			{
				(rawScore, p1, p2) => null,
				(rawScore, p1, p2) => null,
			};
			var renderedScore = DisplayScore.Render(new RawScore(0, 1), P1Name, P2Name, namingRules);

			renderedScore.ShouldEqual("<Unknown score>");
		}

	}
}
