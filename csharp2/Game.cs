namespace TennisGame.Tests
{
    internal class Game : GameState
    {
        private Player _player;

        public Game(Player player)
            : base(Score.Love, Score.Love) // TODO: don't care but still needed for now...
        {
            _player = player;
        }

        internal override string SayScore() => $"Game {_player.ToString()}";
    }
}