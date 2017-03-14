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
		    return GetScore(rawScore, player1Name, player2Name);
	    }

		public static string GetScore(RawScore rawScore, string player1Name, string player2Name)
        {
            var score = "";
	        if (rawScore.Player1Score == rawScore.Player2Score)
            {
                switch (rawScore.Player1Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (rawScore.Player1Score >= 4 || rawScore.Player2Score >= 4)
	        {
		        var minusResult = (int)rawScore.Player1Score - (int)rawScore.Player2Score;
		        switch (minusResult)
		        {
			        case 1:
				        score = $"Advantage {player1Name}";
				        break;
			        case -1:
				        score = $"Advantage {player2Name}";
				        break;
			        default:
				        score = minusResult >= 2 ? $"Win for {player1Name}" : $"Win for {player2Name}";
				        break;
		        }
	        }
            else
            {
                for (var i = 1; i < 3; i++)
                {
	                uint tempScore;
	                if (i == 1) tempScore = rawScore.Player1Score;
                    else { score += "-"; tempScore = rawScore.Player2Score; }
	                switch (tempScore)
	                {
		                case 0:
			                score += "Love";
			                break;
		                case 1:
			                score += "Fifteen";
			                break;
		                case 2:
			                score += "Thirty";
			                break;
		                case 3:
			                score += "Forty";
			                break;
	                }
                }
            }
            return score;
        }
    }
}

