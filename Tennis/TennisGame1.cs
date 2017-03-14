namespace Tennis
{
	internal class TennisGame1
    {
        private readonly string player1Name;
        private readonly string player2Name;
	    private readonly RawScore rawScore = new RawScore();

	    public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
	        this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                rawScore.Player1Scores();
            else
                rawScore.Player2Scores();
        }

	    public string GetScore()
	    {
		    return DisplayScore.Render(rawScore, player1Name, player2Name);
	    }
    }
}

