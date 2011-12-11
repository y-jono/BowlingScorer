using NUnit.Framework;

namespace tddbc.BowlingScorer
{
    class GameTest
    {
        [Test]
        public void 全て投球が1の場合_CaluculateScoreで20が取得できること()
        {
            Game target = new Game();

            for (int i = 0; i < 10;i++ )
            {
                Frame frame = new Frame("1", "1");
                target.AddFrame(frame);
            }

            int actual = target.CaluculateScore();
            int expected = 20;
            Assert.AreEqual(expected, actual);
        }

    }
}
