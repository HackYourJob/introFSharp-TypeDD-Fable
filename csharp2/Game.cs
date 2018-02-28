using System;

namespace TennisGame.Tests
{
    internal class Game
    {
        private GameState _gameState;

        public string SayScore()
        {
            return _gameState.SayScore();
        }

        public Game()
        {
            _gameState = new PointScore(Score.Love, Score.Love);
        }

        public Game(GameState gameState)
        {
            _gameState = gameState;
        }

        internal Game ScoreAPoint(Player player)
        {
            _gameState = _gameState.ScoreAPoint(player);
            return this;
        }
    }
}