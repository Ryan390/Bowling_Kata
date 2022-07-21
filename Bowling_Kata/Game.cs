namespace Bowling_Kata
{
    public class Game
    {
        private int _currentRoll;
        private int _score;
        private readonly int[] _rolls = new int[21];
        
        public void Roll(int pins)
        {
            _rolls[_currentRoll] += pins;
            _currentRoll++;
        }

        public int Score()
        {
            _currentRoll = 0;

            for (var i = 0; i < 10; i++)
            {
                if (IsStrike())
                {
                    AddStrikeBonus();
                }
                else if (IsSpare())
                {
                    AddSpareBonus();
                }
                else
                {
                    AddRegularScore();
                }
            }

            return _score;
        }

        private void AddStrikeBonus()
        {
            _score += 10 + _rolls[_currentRoll + 1] + _rolls[_currentRoll + 2];
            _currentRoll++;
        }

        private bool IsStrike()
        {
            return _rolls[_currentRoll] == 10;
        }

        private void AddRegularScore()
        {
            _score += _rolls[_currentRoll];
            _currentRoll++;
        }

        private void AddSpareBonus()
        {
            _score += 10 + _rolls[_currentRoll + 2];
            _currentRoll += 2;
        }

        private bool IsSpare()
        {
            return _rolls[_currentRoll] + _rolls[_currentRoll + 1] == 10;
        }
    }
}