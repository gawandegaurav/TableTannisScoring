using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennis.Console.Models;

namespace TableTennis.Tests
{
    [TestClass]
    public class TableTennisGameTests
    {
        private readonly Player _playerOne;
        private readonly Player _playerTwo;
        private const string PlayerOneName = "PlayerOne";
        private const string PlayerTwoName = "PlayerTwo";
        private const bool PointToPlayerOne = true;

        public TableTennisGameTests()
        {
            _playerOne = new Player(PlayerOneName);
            _playerTwo = new Player(PlayerTwoName);
        }

        [TestMethod]
        public void GivenScoreIsNotTie_WhenPlayerOneScores11ThPoint_ThenPlayerOneIsWinner()
        {
            // Arrange

            _playerOne.Score = 10;
            _playerTwo.Score = 5;
            var game = new TableTennisGame(_playerOne, _playerTwo);
            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.GetWinner();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerOneName, result.Name);
            Assert.AreEqual(11, result.Score);
        }

        [TestMethod]
        public void GivenBothPlayersTieAt10Points_WhenAPlayerScores11ThPoint_ThenThereIsNoWinner()
        {
            // Arrange

            _playerOne.Score = 9;
            _playerTwo.Score = 10;

            var game = new TableTennisGame(_playerOne, _playerTwo);
            game.UpdateScore(PointToPlayerOne);
            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.HasWinner();

            // Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenBothPlayerHadTieAt10Points_WhenPlayerOneHasTwoPointLead_ThenPlayerOneIsReturedAsWinner()
        {
            // Arrange

            _playerOne.Score = 10;
            _playerTwo.Score = 10;

            var game = new TableTennisGame(_playerOne, _playerTwo);
            game.UpdateScore(PointToPlayerOne);
            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.GetWinner();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerOneName, result.Name);
            Assert.AreEqual(12, result.Score);
        }

        [TestMethod]
        public void GivenBothPlayerHadTieAt20Points_WhenPlayerOneHasOnePointLead_ThenPlayerOneIsReturedAsWinner()
        {
            // Arrange

            _playerOne.Score = 20;
            _playerTwo.Score = 20;

            var game = new TableTennisGame(_playerOne, _playerTwo);

            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.GetWinner();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerOneName, result.Name);
            Assert.AreEqual(21, result.Score);
        }
    }
}