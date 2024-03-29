using System;
using Xunit;
using FluentAssertions;

namespace TennisGame.Tests
{
    public class GameShould
    {
        [Fact]
        public void StartWithLoveLove()
        {
            var game = new GameRunner();
            game.SayScore().Should().Be("Love-Love");
        }

        [Fact]
        public void ReturnFifteenLoveWhenPlayer1Scores()
        {
            var game = new GameRunner();
            game.ScoreAPoint(Player.Player1);
            game.SayScore().Should().Be("Fifteen-Love");
        }

        [Fact]
        public void ReturnLoveFifteenWhenPlayer2Scores()
        {
            var game = new GameRunner();
            game.ScoreAPoint(Player.Player2);
            game.SayScore().Should().Be("Love-Fifteen");
        }

        [Fact]
        public void ReturnLoveThirtyWhenPlayer2Scores2Points()
        {
            var game = new GameRunner();
            game.ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2);
            game.SayScore().Should().Be("Love-Thirty");
        }

        [Fact]
        public void ReturnLoveFortyWhenPlayer2Scores3Points()
        {
            var game = new GameRunner();
            game.ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2);
            game.SayScore().Should().Be("Love-Forty");
        }

        [Fact]
        public void ReturnPlayer2WonGameWhenPlayer2Scores4Points()
        {
            var game = new GameRunner();
            game.ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2);
            game.SayScore().Should().Be("Game Player2");
        }

        [Fact]
        public void ReturnPlayer1WonGameWhenScoreIsFortyThirtyAndPlayer1Scores()
        {
            var game = new GameRunner(new PointScore(Score.Forty, Score.Thirty));
            game.ScoreAPoint(Player.Player1);
            game.SayScore().Should().Be("Game Player1");
        }

        [Fact]
        public void ReturnPlayer1AdvantageWhenScoreIsDeuceAndPlayer1Scores()
        {
            var game = new GameRunner(new Deuce());
            game.ScoreAPoint(Player.Player1);
            game.SayScore().Should().Be("Advantage Player1");
        }

        [Fact]
        public void ReturnPlayer1WonGameWhenScoreIsAdvantagePlayer1AndPlayer1Scores()
        {
            var game = new GameRunner(new Advantage(Player.Player1));
            game.ScoreAPoint(Player.Player1);
            game.SayScore().Should().Be("Game Player1");
        }

        [Fact]
        public void ReturnDeuceWhenScoreIsAdvantagePlayer1AndPlayer2Scores()
        {
            var game = new GameRunner(new Advantage(Player.Player1));
            game.ScoreAPoint(Player.Player2);
            game.SayScore().Should().Be("Deuce");
        }
    }
}
