using TableTennis.Console.Models;

namespace TableTennis.Console.Services
{
    internal interface ITableTennisGameService
    {
        void StartGame(Player PlayerOne, Player PlayerTwo);

        Player ServingPlayer();

        void UpdateScore(bool pointToPlayerOne);

        bool HasWinner();

        Player GetWinner();
    }
}