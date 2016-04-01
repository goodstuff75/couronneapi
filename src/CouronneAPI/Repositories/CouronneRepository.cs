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


        public CouronneRepository(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public int CreateGame(int player1, int player2)
        {
            return 1;
        }

        public int CreatePlayer(Player player)
        {
            var context = ServiceProvider.GetService<ApplicationDbContext>();

         
                context.Players.Add(new DataAccess.Entities.Player()
                {
                    Created = DateTime.Now,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    UserName = player.UserName
                });

                return context.SaveChanges();

            
        }

        public List<Player> GetHighscoreList()
        {
            var list = new List<Player>();
            list.Add(new Player() { FirstName = "Gustaf", LastName = "Andersson", UserName = "Garfield", Created = DateTime.Now });
            return list;
        }

        public List<Player> GetHighscoreListByMonth(int month)
        {
            throw new NotImplementedException();
        }

        public bool SetWinner(int player, int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
