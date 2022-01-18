using TableTennis.Console.Models;

namespace TableTennis.Console.Services
{
    public class TableTennisGameService : ITableTennisGameService
    {
        private TableTennisGame _game;
        public TableTennisGameService()
        {
        }

        public void StartGame(Player PlayerOne, Player PlayerTwo)
        {
            _game = new TableTennisGame(PlayerOne, PlayerTwo);
        }

        public void UpdateScore(bool isPointForPlayerOne)
        {
            _game.UpdateScore(isPointForPlayerOne);
        }

        public bool HasWinner()
        {
            return _game.HasWinner();
        }

        public Player GetWinner()
        {
            return _game.GetWinner();
        }
    }
}
