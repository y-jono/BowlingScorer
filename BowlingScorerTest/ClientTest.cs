using NUnit.Framework;

namespace tddbc.BowlingScorer
{
    public class ClientTest
    {
        [Test]
        [Ignore("GameクラスとFrameクラスを実装後、テストする")]
        void スコアの文字列を入力すると点数が戻る()
        {
            string input = "[[5,3],[7,2],[8,/],[X],[7,1],[9,-],[6,2],[X],[6,/],[8,-]]";
            Client target = new Client();
            int expected = 126;
            int actual = target.CalculateScore(input);
            Assert.AreEqual(expected, actual);
        }

    }
}
