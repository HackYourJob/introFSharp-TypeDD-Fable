using System;

namespace TennisGame.Tests
{
    internal class Game
    {
        public Score Player1Score { get; private set; }
        public Score Player2Score { get; private set; }
        
        private GameState State
        {
            get
            {
                if (Player1Score == Score.Forty && Player2Score == Score.Forty)
                    return GameState.Deuce;
                if (Player1Score == Score.Advantage || Player2Score == Score.Advantage)
                    return GameState.Advantage;
                return GameState.PointScore;
            }
        }

        public Game()
        {
        }

        public Game(Score player1Score, Score player2Score)
        {
            this.Player1Score = player1Score;
            this.Player2Score = player2Score;
        }

        internal Game ScoreAPoint(Player player)
        {
            if (State == GameState.PointScore)
            {
                if (player == Player.Player1)
                    Player1Score = AddPoint(Player1Score);
                else
                    Player2Score = AddPoint(Player2Score);
            }
            else if (State == GameState.Deuce)
            {
                if (player == Player.Player1)
                    Player1Score = Score.Advantage;
                else
                    Player2Score = Score.Advantage;
            }
            else if (State == GameState.Advantage)
            {
                if (player == Player.Player1)
                    if (Player2Score == Score.Advantage)
                        Player2Score = Score.Forty;
                    else
                        Player1Score = Score.Game;
                else
                    if (Player2Score == Score.Advantage)
                    Player2Score = Score.Game;
                else
                    Player1Score = Score.Forty;
            }
            return this;
        }

        private Score AddPoint(Score playerScore)
        {
            if (playerScore == Score.Love)
                return Score.Fifteen;
            else if (playerScore == Score.Fifteen)
                return Score.Thirty;
            else if (playerScore == Score.Thirty)
                return Score.Forty;
            else
                return Score.Game;
        }
    }
}