using System;

namespace TennisKata
{
    internal class Game
    {
        private PlayerScore _player1Score = PlayerScore.Love;
        private PlayerScore _player2Score = PlayerScore.Love;

        internal string Score
        {
            get
            {
                if (_player1Score == PlayerScore.Game)
                    return "Game Player 1";

                if (_player2Score == PlayerScore.Game)
                    return "Game Player 2";

                if (_player1Score == PlayerScore.Forty && _player2Score == PlayerScore.Forty)
                    return "Deuce";

                if (_player1Score == PlayerScore.Advantage)
                    return "Advantage Player 1";

                return $"{_player1Score}-{_player2Score}";
            }
        }

        internal void Player1Scores()
        {
            (_player1Score, _player2Score) = AddPoint(_player1Score, _player2Score);
        }

        internal void Player2Scores()
        {
            (_player2Score, _player1Score) = AddPoint(_player2Score, _player1Score);
        }

        private (PlayerScore, PlayerScore) AddPoint(PlayerScore score, PlayerScore otherScore)
        {
            if (score == PlayerScore.Forty && otherScore == PlayerScore.Advantage)
                return (PlayerScore.Forty, PlayerScore.Forty);
            if (score == PlayerScore.Forty && otherScore != PlayerScore.Forty)
                return (PlayerScore.Game, otherScore);
            return (score + 1, otherScore);
        }
    }
}