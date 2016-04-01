using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CouronneAPI.Repositories;
using CouronneAPI.Models;
using CouronneAPI.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CouronneAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {

        [FromServices]
        public ICouronneRepository CouronneRepository { get; set; }

        public String Index()
        {
            return "Hello, this is the player Controller";
        }

        [Route("create")]
        [HttpGet]
        public int CreatePlayer()
        {
            var player = new Player() { FirstName = "Gustaf", LastName = "Andersson", UserName = "Garfield", Created = DateTime.Now };
            return CouronneRepository.CreatePlayer(player);
        }
        
        [Route("gethighscorelist")]
        [HttpGet]
        public List<Player> GetPlayersByScore()
        {
            return CouronneRepository.GetHighscoreList();
        }

        [Route("gethighscorelistbymonth")]
        [HttpGet]
        public List<Player> GetPlayersByScoreAndMonth(int month)
        {
            return CouronneRepository.GetHighscoreListByMonth(month);
        }
    }
}
