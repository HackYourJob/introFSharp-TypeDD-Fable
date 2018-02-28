namespace TennisGame.Tests
{
    internal class Deuce : GameState
    {
        public Deuce()
            : base(Score.Love, Score.Love) // TODO : useless but needed, so put some random value to avoid side effects
        {
        }

        internal override string SayScore() => "Deuce";

        internal override GameState ScoreAPoint(Player player)
            => new Advantage(player);
    }
}