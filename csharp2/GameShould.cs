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
            var game = new Game();
            game.Player1Score.Should().Be(Score.Love);
            game.Player2Score.Should().Be(Score.Love);
        }

        [Fact]
        public void ReturnFifteenLoveWhenPlayer1Scores()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player1);
            game.Player1Score.Should().Be(Score.Fifteen);
            game.Player2Score.Should().Be(Score.Love);
        }

        [Fact]
        public void ReturnLoveFifteenWhenPlayer2Scores()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.Player1Score.Should().Be(Score.Love);
            game.Player2Score.Should().Be(Score.Fifteen);
        }

        [Fact]
        public void ReturnLoveThirtyWhenPlayer2Scores2Points()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2);
            game.Player1Score.Should().Be(Score.Love);
            game.Player2Score.Should().Be(Score.Thirty);
        }

        [Fact]
        public void ReturnLoveFortyWhenPlayer2Scores3Points()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2);
            game.Player1Score.Should().Be(Score.Love);
            game.Player2Score.Should().Be(Score.Forty);
        }

        [Fact]
        public void ReturnPlayer2WonGameWhenPlayer2Scores4Points()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2)
                .ScoreAPoint(Player.Player2);
            game.Player1Score.Should().Be(Score.Love);
            game.Player2Score.Should().Be(Score.Game);
        }

        [Fact]
        public void ReturnPlayer1WonGameWhenScoreIsFortyThirtyAndPlayer1Scores()
        {
            var game = new Game(Score.Forty, Score.Thirty);
            game.ScoreAPoint(Player.Player1);
            game.Player1Score.Should().Be(Score.Game);
            game.Player2Score.Should().Be(Score.Thirty);
        }

        [Fact]
        public void ReturnPlayer1AdvantageWhenScoreIsDeuceAndPlayer1Scores()
        {
            var game = new Game(Score.Forty, Score.Forty);
            game.ScoreAPoint(Player.Player1);
            game.Player1Score.Should().Be(Score.Advantage);
            game.Player2Score.Should().Be(Score.Forty);
        }

        [Fact]
        public void ReturnPlayer1WonGameWhenScoreIsAdvantagePlayer1AndPlayer1Scores()
        {
            var game = new Game(Score.Advantage, Score.Forty);
            game.ScoreAPoint(Player.Player1);
            game.Player1Score.Should().Be(Score.Game);
            game.Player2Score.Should().Be(Score.Forty);
        }

        [Fact]
        public void ReturnDeuceWhenScoreIsAdvantagePlayer1AndPlayer2Scores()
        {
            var game = new Game(Score.Advantage, Score.Forty);
            game.ScoreAPoint(Player.Player2);
            game.Player1Score.Should().Be(Score.Forty);
            game.Player2Score.Should().Be(Score.Forty);
        }
    }
}
