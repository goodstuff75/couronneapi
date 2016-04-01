using System;
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

        public CouronneRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Context = ServiceProvider.GetService<ApplicationDbContext>();
        }
        public int CreateGame(int player1, int player2)
        {
            return 1;
        }

        public int CreatePlayer(Player player)
        {
            Context.Players.Add(new DataAccess.Entities.Player()
                {
                    Created = DateTime.Now,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    UserName = player.UserName
                });

                return Context.SaveChanges();
        }

        public List<Player> GetHighscoreList()
        {
            return Context.Players.Select(player=>new Player {Created = player.Created,FirstName = player.FirstName,Id=player.Id,LastName = player.LastName,UserName = player.UserName}).ToList();
        }

        public List<Player> GetHighscoreListByMonth(int month)
        {
            return Context.Players.Where(player=>player.Created.Month == month).Select(player => new Player { Created = player.Created, FirstName = player.FirstName, Id = player.Id, LastName = player.LastName, UserName = player.UserName }).ToList();
        }

        public bool SetWinner(int player, int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
