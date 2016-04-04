using System;
using System.Collections.Generic;
using CouronneAPI.Models;

namespace CouronneAPI.Repositories.Interfaces
{
    public interface ICouronneRepository
    {
        int CreatePlayer(Player player);
        int CreateGame(int player1, int player2);
        int SetWinner(int player, int gameId);
        List<Player> GetHighscoreList();
        List<Player> GetHighscoreListByMonth(int month);
        Player GetPlayer(int id);
        Game GetGame(int id);
    }
}