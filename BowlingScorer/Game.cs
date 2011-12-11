using System.Collections.Generic;

namespace tddbc.BowlingScorer
{
    public class Game
    {
        private List<Frame> _frameList = new List<Frame>(10);
 
        public void AddFrame(Frame frame)
        {
            this._frameList.Add(frame);
        }

        public int CaluculateScore()
        {
            int score = 0;
            for (int i =0 ; i<8;i++)
            {
                Frame current = _frameList[i];
                Frame next = _frameList[i + 1];
                Frame nextnext = _frameList[i + 2];
                score += current.CaluculateScore(next, nextnext);
            }
            score += _frameList[8].CaluculateScore(_frameList[9]);
            score += _frameList[9].CaluculateScore();

            return score;
        }

        
    }
}
