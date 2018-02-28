using System;
using Xunit;
using FluentAssertions;

namespace TennisKata
{
    public class GameShould
    {
        [Fact]
        public void StartAtLoveLove()
        {
            var game = new Game();
            var score = game.Score;
            score.Should().Be("Love-Love");
        }

        [Fact]
        public void ReturnFifteenLoveWhenPlayer1Scores()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player1);
            var score = game.Score;
            score.Should().Be("Fifteen-Love");
        }

        [Fact]
        public void ReturnThirtyLoveWhenPlayer1ScoresTwiceInARow()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            var score = game.Score;
            score.Should().Be("Thirty-Love");
        }

        [Fact]
        public void ReturnFortyLoveWhenPlayer1Scores3TimesInARow()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            var score = game.Score;
            score.Should().Be("Forty-Love");
        }

        [Fact]
        public void ReturnGamePlayer1WhenPlayer1Scores4TimesInARow()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            var score = game.Score;
            score.Should().Be("Game Player 1");
        }

        [Fact]
        public void ReturnLoveFifteenWhenPlayer2Scores()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            var score = game.Score;
            score.Should().Be("Love-Fifteen");
        }

        [Fact]
        public void ReturnLoveThirtyWhenPlayer2ScoresTwoInARow()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            var score = game.Score;
            score.Should().Be("Love-Thirty");
        }

        [Fact]
        public void ReturnLoveFortyWhenPlayer2ScoresThreeInARow()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            var score = game.Score;
            score.Should().Be("Love-Forty");
        }


        [Fact]
        public void ReturnGamePlayer2WhenPlayer2Scores4timesInARow()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            var score = game.Score;
            score.Should().Be("Game Player 2");
        }

        [Fact]
        public void ReturnDeuceWhenPlayer1AndPlayer2Scores3TimesEach()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            var score = game.Score;
            score.Should().Be("Deuce");
        }

        [Fact]
        public void ReturnAdvantagePlayer1WhenPlayer1ScoresAfterDeuce()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);

            var score = game.Score;
            score.Should().Be("Advantage Player 1");
        }

        [Fact]
        public void ReturnDeuceWhenPlayer1ScoresAfterDeuceThenPlayer2Scores()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player2);

            var score = game.Score;
            score.Should().Be("Deuce");
        }

        [Fact]
        public void ReturnGamePlayer1WhenPlayer1ScoresAfterAdvantage()
        {
            var game = new Game();
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player2);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);
            game.ScoreAPoint(Player.Player1);

            var score = game.Score;
            score.Should().Be("Game Player 1");
        }
    }
}
