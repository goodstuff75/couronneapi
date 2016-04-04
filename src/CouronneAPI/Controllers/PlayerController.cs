using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
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

        public ActionResult Index()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public string CreatePlayer(Player player)
        {
            return string.Format("Player created with id: {0}", CouronneRepository.CreatePlayer(player));
        }

        [Route("getplayerbyid")]
        [HttpGet]
        public Player GetPlayersById(int id)
        {
            return CouronneRepository.GetPlayer(id);
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
