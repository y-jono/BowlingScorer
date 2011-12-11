using System.Diagnostics;
using NUnit.Framework;

namespace tddbc.BowlingScorer
{
    public class FrameTest
    {
        [TestFixture]
        public class Defult
        {

            [TestCase("1", Result = 1)]
            [TestCase("2", Result = 2)]
            [TestCase("9", Result = 9)]
            public int ToScoreに数値文字を入力した場合数値を取得できる(string input)
            {
                int actual = Frame.Transrate(input);
                //Assert.AreEqual(expected, actual);
                return actual;
            }

            [Test]
            public void ToScoreにガターを入力した場合0を取得できる()
            {
                int expected = 0;
                int actual = Frame.Transrate("-");
                Assert.AreEqual(expected, actual);               
            }

            [Test]
            public void ToScoreにストライクを入力した場合10を取得できる()
            {
                int expected = 10;
                int actual = Frame.Transrate("X");
                Assert.AreEqual(expected, actual);
            }

        }


        [TestFixture]
        public class Frameのコンストラクタに1とガターを与えた場合
        {
            private Frame _target;

             [SetUp]
            public void Setup()
             {
                this._target  = new Frame("1", "-");
                  
             }

            [Test]
            public void Firstで1が取得できる()
            {
                string actual = this._target.First;
                string expected = "1";

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void Secondでガターが取得できる()
            {
                string actual = this._target.Second;
                string expected = "-";
                
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void 引数なしのCalculateScoreを呼ぶとFirstとSecondの合計が取得できる()
            {
                int actual = this._target.CaluculateScore();
                int expected = 1;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class Frameのコンストラクタに1と9を与えた場合
        {
            private Frame _target;

            [SetUp]
            public void Setup()
            {
                this._target = new Frame("1", "9");
            }

            [Test]
            public void 引数なしのCalculateScoreを呼ぶと10が取得できる()
            {
                int actual = _target.CaluculateScore();
                int expected = 10;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void 引数が1つのCaluculateScoreを呼ぶと10が取得できる()
            {
                var frame = new Frame("1", "2");
                int actual = _target.CaluculateScore(frame);
                int expected = 10;
                Assert.AreEqual(expected, actual);                
            }
    

        
        }


        [TestFixture]
        public class Frameのコンストラクタに2とスペアを与えた場合
        {
            private Frame _target;

            [SetUp]
            public void Setup()
            {
                this._target = new Frame("2", "/");
            }

            [TestFixture]
            public class 次のFrameのコンストラクタに1と2を与えた場合
            {
                private Frame _nextFrame;
                private Frame _target;


                [SetUp]
                public void Setup()
                {
                    this._target = new Frame("2", "/");
                    this._nextFrame = new Frame("1", "2");
                }


                [Test]
                public void 引数が1つのCaluculateScoreを呼ぶと11が取得できる()
                {
                    int actual = _target.CaluculateScore(_nextFrame);
                    int expected = 11;
                    Assert.AreEqual(expected, actual);
                }

            }


            
    
        }

        [TestFixture]
        public class Frameのコンストラクタにストライクを与えた場合
        {

            private Frame _target;

            [SetUp]
            public void Setup()
            {
                _target = new Frame("X");
            }

            [Test]
            public void FirstでXが取得できる()
            {
                string actual = this._target.First;
                string expected = "X";

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void Secondで空文字が取得できる()
            {
                string actual = this._target.Second;
                string expected = string.Empty;

                Assert.AreEqual(expected, actual);
            }

            [TestFixture]
            public class 次のFrameのコンストラクタに1と2を与えた場合
            {
                private Frame _nextFrame;
                private Frame _target;


                [SetUp]
                public void Setup()
                {
                    this._target = new Frame("X");
                    this._nextFrame = new Frame("1", "2");
                }


                [Test]
                public void 引数が1つのCaluculateScoreを呼ぶと13が取得できる()
                {
                    int actual = _target.CaluculateScore(_nextFrame);
                    int expected = 10 + 1 + 2;
                    Assert.AreEqual(expected, actual);
                }



            }

            [TestFixture]
            public class 次のFrameのコンストラクタにXを与えた場合
            {
                private Frame _nextFrame;
                private Frame _target;
                private Frame _nextNextFrame;

                [SetUp]
                public void Setup()
                {
                    this._target = new Frame("X");
                    this._nextFrame = new Frame("X");
                    this._nextNextFrame = new Frame("1","2");
                }

                [Test]
                public void 引数が2つのCaluculateScoreを呼ぶと21が取得できる()
                {
                    int actual = _target.CaluculateScore(_nextFrame, _nextNextFrame);
                    int expected = 10 + 10 + 1;
                    Assert.AreEqual(expected, actual);
                }


            }

        }
    }
}
