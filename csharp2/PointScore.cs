namespace TennisGame.Tests
{
    public class PointScore : GameState
    {
        private readonly Score _player1Score;
        private readonly Score _player2Score;

        public PointScore(Score player1Score, Score player2Score) 
            : base(player1Score, player2Score)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        internal override string SayScore()
        {
            if (_player1Score == Score.Game)
                return "Game Player1";
            if (_player2Score == Score.Game)
                return "Game Player2";
            return $"{_player1Score.ToString()}-{_player2Score.ToString()}";
        }

        internal override GameState ScoreAPoint(Player player)
        {
            var (player1Score, player2Score) = player == Player.Player1 
                ? (AddPoint(_player1Score), _player2Score)
                : (_player1Score, AddPoint(_player2Score));
                
            if (player1Score == Score.Forty && player2Score == Score.Forty)
                return new GameState(Score.Forty, Score.Forty); // TODO to replace by Deuce
            return new PointScore(player1Score, player2Score);
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