using System;
using NUnit.Framework;
using Should;

namespace Tennis.Tests
{
	internal class CreatingPlayer
	{
		[Test]
		public void NullNameNotAllowed()
		{
			Action action = () => new Player(null);

			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void SameNameDetected()
		{
			var p1 = new Player("a");
			var p2 = new Player("a");

			p1.HasSameNameAs(p2).ShouldBeTrue();
		}

		[Test]
		public void DifferentNameDetected()
		{
			var p1 = new Player("a");
			var p2 = new Player("b");

			p1.HasSameNameAs(p2).ShouldBeFalse();
		}

		[Test]
		public void NullOtherPLayerNotSameName()
		{
			var p1 = new Player("a");

			p1.HasSameNameAs(null).ShouldBeFalse();
		}

	}
}