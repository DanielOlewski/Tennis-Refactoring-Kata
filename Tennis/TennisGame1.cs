using System;

namespace Tennis
{
	internal class TennisGame1
    {
        private readonly string player1Name;
        private readonly string player2Name;
	    private readonly RawScore rawScore = new RawScore();

	    public TennisGame1(string player1Name, string player2Name)
        {
	        ValidatePlayerNames(player1Name, player2Name);

	        this.player1Name = player1Name;
	        this.player2Name = player2Name;
        }

	    private static void ValidatePlayerNames(string player1Name, string player2Name)
	    {
		    if (string.IsNullOrEmpty(player1Name) || string.IsNullOrEmpty(player2Name))
		    {
			    throw new ArgumentException("Player names must be provided!");
		    }

		    if (player1Name == player2Name)
		    {
			    throw new ArgumentException("Player names must be different!");
		    }
	    }

	    public void WonPoint(string playerName)
        {
	        if (playerName == player1Name)
	        {
		        rawScore.Player1Scores();
	        }
            else if (playerName == player2Name)
            {
	            rawScore.Player2Scores();
            }
            else
            {
	            throw new ArgumentException("Unknown player name: " + playerName);
            }
        }

		public string Score => DisplayScore.Render(rawScore, player1Name, player2Name);
    }
}

