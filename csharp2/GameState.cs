using System;

namespace TennisGame.Tests
{
    public abstract class GameState
    {
        internal abstract string SayScore();

        internal abstract GameState ScoreAPoint(Player player);
    }
}
