namespace Tennis
{
    internal class Scorer
    {
        public delegate void ScoreHandler(ScoringData scoringData);

        public event ScoreHandler ScoreReady;

        public void Score(ScoringData scoringData)
        {
            string score = "";
            if (ScoreEqual(scoringData))
            {
                switch (scoringData.Points1)
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
            else if (OnePlayerScoredFourOrHigher(scoringData))
            {
                if (Player1PointAdvantage(scoringData) == 1) score = "Advantage " + scoringData.Player1Name;
                else if (Player2PointAdvantage(scoringData) == 1) score = "Advantage " + scoringData.Player2Name;
                else if (Player1PointAdvantage(scoringData) == 2) score = "Win for " + scoringData.Player1Name;
                else if (Player2PointAdvantage(scoringData) == 2) score = "Win for " + scoringData.Player2Name;
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = scoringData.Points1;
                    else
                    {
                        score += "-";
                        tempScore = scoringData.Points2;
                    }
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

            scoringData.Score = score;

            if (ScoreReady != null)
            {
                ScoreReady(scoringData);
            }
        }

        private static bool OnePlayerScoredFourOrHigher(ScoringData scoringData)
        {
            return scoringData.Points1 >= 4 || scoringData.Points2 >= 4;
        }

        private static bool ScoreEqual(ScoringData scoringData)
        {
            return scoringData.Points1 == scoringData.Points2;
        }

        private static int Player1PointAdvantage(ScoringData scoringData)
        {
            if (scoringData.Points1 > scoringData.Points2)
            {
                return scoringData.Points1 - scoringData.Points2;
            }

            return 0;
        }

        private static int Player2PointAdvantage(ScoringData scoringData)
        {
            if (scoringData.Points2 > scoringData.Points1)
            {
                return scoringData.Points2 - scoringData.Points1;
            }

            return 0;
        }
    }
}