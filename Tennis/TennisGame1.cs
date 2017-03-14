namespace Tennis
{
	internal class TennisGame1 : ITennisGame
    {
        private int m_score1;
        private int m_score2;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
	        this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            var score = "";
	        if (m_score1 == m_score2)
            {
                switch (m_score1)
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
            else if (m_score1 >= 4 || m_score2 >= 4)
	        {
		        var minusResult = m_score1 - m_score2;
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
	                int tempScore;
	                if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
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

