namespace TennisGame.Tests
{
    internal class Deuce : GameState
    {
        internal override string SayScore() => "Deuce";

        internal override GameState ScoreAPoint(Player player)
            => new Advantage(player);
    }
}