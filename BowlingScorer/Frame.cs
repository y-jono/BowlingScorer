namespace tddbc.BowlingScorer
{
    public class Frame
    {
        private string _first;
        private string _second;
        public string First { get { return _first; } private set { _first = value; } }
        public string Second { get { return _second; } private set { _second = value; } }

            
        public Frame(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }

        public Frame(string first) : this(first, string.Empty)
        {
        }

        public static int Transrate(string input)
        {
            int score;

            switch (input)
            {
                case "-":
                    return 0;
                case "X":
                    return 10;
            }

            if (!int.TryParse(input, out score))
            {
                throw new System.ArgumentException("無効な数値文字が入力されました。");
            }

            return score;
        }

        public int CaluculateScore()
        {
            return CaluculateScore(null,null);
        }


        public int CaluculateScore(Frame nextFrame)
        {
            return this.CaluculateScore(nextFrame, null);
        }

        public int CaluculateScore(Frame nextFrame, Frame nextNextFrame)
        {
            if (this.Second == "/")
            {
                return 10 + Transrate(nextFrame.First);
            }
            else if (this.First == "X")
            {
                if(nextFrame.First == "X")
                {
                    return 10 + Transrate(nextFrame.First) + Transrate(nextNextFrame.First);
                }
                return 10 + Transrate(nextFrame.First) + Transrate(nextFrame.Second);
            }

            int first = Transrate(this.First);
            int second = Transrate(this.Second);

            return first + second;
        }

    }
}
