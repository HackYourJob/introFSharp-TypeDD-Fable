using System;

namespace TennisGame.Tests
{
    public class GameState
    {
        public GameState(Score player1Score, Score player2Score)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
        }

        internal virtual string SayScore()
        {
            if (Player1Score == Score.Forty && Player2Score == Score.Forty)
            {
                return "Deuce";
            }
            if (Player1Score == Score.Advantage)
            {
                return "Advantage Player1";
            }
            if (Player2Score == Score.Advantage)
            {
                return "Advantage Player2";
            }
            return ".....";
        }

        public Score Player1Score { get; private set; }
        public Score Player2Score { get; private set; }
        
        private StateEnum State
        {
            get
            {
                if (Player1Score == Score.Forty && Player2Score == Score.Forty)
                    return StateEnum.Deuce;
                if (Player1Score == Score.Advantage || Player2Score == Score.Advantage)
                    return StateEnum.Advantage;
                return StateEnum.PointScore;
            }
        }

        internal virtual GameState ScoreAPoint(Player player)
        {
            if (State == StateEnum.Deuce)
            {
                if (player == Player.Player1)
                    Player1Score = Score.Advantage;
                else
                    Player2Score = Score.Advantage;
            }
            else if (State == StateEnum.Advantage)
            {
                if (player == Player.Player1)
                    if (Player2Score == Score.Advantage)
                        Player2Score = Score.Forty;
                    else
                        return new Game(player);
                else if (Player2Score == Score.Advantage)
                    return new Game(player);
                else
                    Player1Score = Score.Forty;
            }
            return this;
        }

        private enum StateEnum
        {
            PointScore,
            Deuce,
            Advantage,
            Game
        }
    }
}