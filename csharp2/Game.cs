namespace TennisGame.Tests
{
    internal class Game : GameState
    {
        private Player _player;

        public Game(Player player)
        {
            _player = player;
        }

        internal override string SayScore() => $"Game {_player.ToString()}";

        internal override GameState ScoreAPoint(Player player) => this;
    }
}