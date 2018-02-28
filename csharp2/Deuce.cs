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
            => player == Player.Player1
                ? new GameState(Score.Advantage, Score.Forty)
                : new GameState(Score.Forty, Score.Advantage);
    }
}