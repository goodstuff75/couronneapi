﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouronneAPI.Models;
using CouronneAPI.Repositories.Interfaces;
using DataAccess;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CouronneAPI.Repositories
{
    public class CouronneRepository : ICouronneRepository
    {
     
        public IServiceProvider ServiceProvider { get; set; }
        public ApplicationDbContext Context { get; set; }
        public ApplicationDbContext Context2 { get; set; }

        public CouronneRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Context = ServiceProvider.GetService<ApplicationDbContext>();

        }
        public int CreateGame(int player1, int player2)
        {
            Context.Games.Add(new DataAccess.Entities.Game()
            {
                PlayDate = DateTime.Now,
                Player1 = player1,
                Player2 = player2
          
            });

            return Context.SaveChanges();
        }

        public int CreatePlayer(Player player)
        {
            Context.Players.Add(new DataAccess.Entities.Player()
                {
                    Created = DateTime.Now,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    UserName = player.UserName,
                    Wins = 0
                });

                return Context.SaveChanges();
        }

        public List<Player> GetHighscoreList()
        {
            return Context.Players.Select(player=>new Player {Created = player.Created,FirstName = player.FirstName,Id=player.Id,LastName = player.LastName,UserName = player.UserName,Games = GetGames(player.Id),Wins = GetWins(player.Id) }).OrderByDescending(x=>x.Wins).ToList();
        }

        private int GetWins(int id)
        {
            return Context.Games.Count(game => game.Winner == id);
        }

        private List<Game> GetGames(int id)
        {
            return
                Context.Games.Where(game => game.Player1 == id || game.Player2 == id)
                    .Select(
                        game =>
                            new Game
                            {
                                Id = game.Id,
                                PlayDate = game.PlayDate,
                                Player1 = game.Player1,
                                Player2 = game.Player2,
                                Winner = game.Winner
                            })
                    .ToList();

           
        }

        public List<Player> GetHighscoreListByMonth(int month)
        {
            return Context.Players.Select(player => new Player { Created = player.Created, FirstName = player.FirstName, Id = player.Id, LastName = player.LastName, UserName = player.UserName, Games = GetGames(player.Id), Wins = GetWinsByMonth(player.Id, month) }).OrderByDescending(x => x.Wins).ToList();
        }

        private int GetWinsByMonth(int id, int month)
        {
            return Context.Games.Where(game=>game.PlayDate.Month == month).Count(game => game.Winner == id);
        }

        public int SetWinner(int player, int gameId)
        {
            var playedGame = Context.Games.First(game => game.Id == gameId);
            playedGame.Winner = player;
            Context.Games.Update(playedGame);
            return Context.SaveChanges();

        }
    }
}
