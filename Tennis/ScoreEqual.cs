namespace Tennis
{
    internal class ScoreEqual : IScorer
    {
        public event ScoreHandler ScoreReady;

        public void Score(ScoringData scoringData, string score)
        {
            if (score == null && scoringData.ScoreEqual)
            {
                score = scoringData.Player1PointsName + "-All";
            }

            ScoreReady?.Invoke(scoringData, score);
        }
    }
}