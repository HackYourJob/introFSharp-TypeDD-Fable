using System;

namespace TennisGame.Tests
{
    internal class GameRunner
    {
        private GameState _gameState;

        public string SayScore()
        {
            return _gameState.SayScore();
        }

        public GameRunner()
        {
            _gameState = new PointScore(Score.Love, Score.Love);
        }

        public GameRunner(GameState gameState)
        {
            _gameState = gameState;
        }

        internal GameRunner ScoreAPoint(Player player)
        {
            _gameState = _gameState.ScoreAPoint(player);
            return this;
        }
    }
}