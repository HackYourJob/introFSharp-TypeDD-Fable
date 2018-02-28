namespace TennisGame.Tests
{
    internal class GameState
    {
        public GameState(Score player1Score, Score player2Score)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
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

        internal GameState ScoreAPoint(Player player)
        {
            if (State == StateEnum.PointScore)
            {
                if (player == Player.Player1)
                    Player1Score = AddPoint(Player1Score);
                else
                    Player2Score = AddPoint(Player2Score);
            }
            else if (State == StateEnum.Deuce)
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

        private enum StateEnum
        {
            PointScore,
            Deuce,
            Advantage,
            Game
        }
    }
}