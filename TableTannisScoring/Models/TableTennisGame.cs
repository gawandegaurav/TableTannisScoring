using System;
namespace TableTennis.Console.Models
{
    public class TableTennisGame
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;
        private Player _winner;
        private bool _need2PointsLead;
        private bool _hasWinner;
        private int _serviceRemaining = 0;

        public TableTennisGame(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public Player GetWinner()
        {
            return _winner;
        }

        public bool HasWinner()
        {
            return _hasWinner;
        }

        public Player GetServingPlayer()
        {
            _serviceRemaining++;

            if (_serviceRemaining <= Constant.NumberOfConsicutiveServices)
            {
                return _playerOne;
            }

            if (_serviceRemaining == Constant.NumberOfConsicutiveServices * 2)
            {
                _serviceRemaining = 0;
            }

            return _playerTwo;
        }

        public void UpdateScore(bool isPointForPlayerOne)
        {
            if (isPointForPlayerOne)
            {
                _playerOne.Score++;
            }
            else
            {
                _playerTwo.Score++;
            }

            _hasWinner = GameHasWinner();
            System.Console.WriteLine($"Score -> {_playerOne.Name} - {_playerOne.Score}  {_playerTwo.Name} - {_playerTwo.Score} \n");
        }

        private bool GameHasWinner()
        {
            CheckForTie();

            var playerOneScore = _playerOne.Score;
            var playerTwoScore = _playerTwo.Score;

            if (_need2PointsLead)
            {
                if (playerOneScore - playerTwoScore == Constant.PointDifferenceToWin)
                {
                    _winner = _playerOne;
                    return true;
                }
                else if (playerTwoScore - playerOneScore == Constant.PointDifferenceToWin)
                {
                    _winner = _playerTwo;
                    return true;
                }
            }
            else if (Constant.WinningScore.Contains(playerOneScore))
            {
                _winner = _playerOne;
                return true;
            }
            else if (Constant.WinningScore.Contains(playerTwoScore))
            {
                _winner = _playerTwo;
                return true;
            }

            return false;
        }

        private void CheckForTie()
        {
            var isTieAt10Points = _playerOne.Score == Constant.TiePoint10 && _playerTwo.Score == Constant.TiePoint10;
            var isTieAt20Points = _playerOne.Score == Constant.TiePoint20 && _playerTwo.Score == Constant.TiePoint20;

            if (isTieAt10Points)
            {
                _need2PointsLead = true;
            }
            else if (isTieAt20Points)
            {
                _need2PointsLead = false;
            }
        }
    }
}