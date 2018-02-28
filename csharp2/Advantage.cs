namespace TennisGame.Tests
{
    internal class Advantage : GameState
    {
        private Player _player;

        public Advantage(Player player)
            : base(Score.Love, Score.Love) // TODO : useless but still needed
        {
            _player = player;
        }

        internal override string SayScore() => $"Advantage {_player.ToString()}";

        internal override GameState ScoreAPoint(Player player)
        {
            if (player == _player)
                return new Game(player);
            return new Deuce();
        }
    }
}