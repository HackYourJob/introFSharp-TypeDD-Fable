using System;

namespace TennisGame.Tests
{
    internal class Game
    {
        private GameState _gameState;

        public Score Player1Score => _gameState.Player1Score;
        public Score Player2Score => _gameState.Player2Score;

        public Game()
        {
            _gameState = new GameState(Score.Love, Score.Love);
        }

        public Game(Score player1Score, Score player2Score)
        {
            _gameState = new GameState(player1Score, player2Score);
        }

        internal Game ScoreAPoint(Player player)
        {
            _gameState = _gameState.ScoreAPoint(player);
            return this;
        }
    }
}