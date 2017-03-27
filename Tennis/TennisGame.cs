using System;

namespace Tennis
{
	internal class TennisGame
    {
        private readonly Player player1;
        private readonly Player player2;
	    private readonly RawScore rawScore = new RawScore();

	    public TennisGame(string player1Name, string player2Name)
        {
	        player1 = new Player(player1Name);
	        player2 = new Player(player2Name);

			ValidatePlayers(player1, player2);
		}

		private static void ValidatePlayers(Player player1, Player player2)
	    {
			if (player1.HasSameNameAs(player2))
			{
				throw new ArgumentException("Player names must be different!");
			}
		}

	    public void WonPoint(string playerName)
        {
			var player = new Player(playerName);

	        if (player.HasSameNameAs(player1))
	        {
		        rawScore.Player1Scores();
	        }
            else if (player.HasSameNameAs(player2))
			{
	            rawScore.Player2Scores();
            }
            else
            {
	            throw new ArgumentException("Unknown player name: " + playerName);
            }
        }

		public string Score => ScoreBoard.Render(rawScore, player1, player2, TennisScoreNaming.Rules);
    }
}

