using Bowling_Kata;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }
        
        [Test]
        public void Roll_OnePin_ScoreIsOne()
        {
            _game.Roll(1);
            Assert.AreEqual(1, _game.Score());
        }
        
        [Test]
        [TestCase(1, 1)]
        [TestCase(3, 3)]
        [TestCase(0, 0)]
        [TestCase(5, 5)]
        [TestCase(9, 9)]
        public void Roll_NoSparesOrStrikes_ScoreIsCorrect(int pins, int expectedScore)
        {
            _game.Roll(pins);
            Assert.AreEqual(expectedScore, _game.Score());
        }

        [Test]
        public void Roll_MultiplePins_ScoreIsCorrect()
        {
            _game.Roll(3);
            _game.Roll(5);
            Assert.AreEqual(8, _game.Score());
        }

        [Test]
        public void Roll_SingleSpare_ScoreIsCorrect()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
            Assert.AreEqual(16, _game.Score());
        }

        [Test]
        public void Roll_MultipleSpares_ScoreIsCorrect()
        {
            _game.Roll(7);
            _game.Roll(3);
            _game.Roll(7);
            _game.Roll(2);
            _game.Roll(2);
            _game.Roll(8);
            _game.Roll(4); 
            
            Assert.AreEqual(44, _game.Score());
        }

        [Test]
        public void Roll_SingleStrike_ScoreIsCorrect()
        {
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(3);
            
            Assert.AreEqual(22, _game.Score());
        }

        [Test]
        public void Roll_MultipleStrikes_ScoreIsCorrect()
        {
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(10);
            _game.Roll(6);
            _game.Roll(2); 
            
            Assert.AreEqual(91, _game.Score());
        }

        [Test]
        public void Roll_PerfectGame_ScoreIs300()
        {
            for (var i = 0; i < 12; i++)
            {
                _game.Roll(10);
            }
            
            Assert.AreEqual(300, _game.Score());
        }
    }
}