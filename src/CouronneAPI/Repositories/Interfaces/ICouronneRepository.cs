using System;
using System.Collections.Generic;
using CouronneAPI.Models;

namespace CouronneAPI.Repositories.Interfaces
{
    public interface ICouronneRepository
    {
        int CreatePlayer(Player player);
        int CreateGame(int player1, int player2);
        bool SetWinner(int player, int gameId);
        List<Player> GetHighscoreList();
        List<Player> GetHighscoreListByMonth(int month);

    }
}