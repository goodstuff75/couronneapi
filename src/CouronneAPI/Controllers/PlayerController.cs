using System.Collections.Generic;
using CouronneAPI.Models;
using CouronneAPI.Repositories.Interfaces;
using Microsoft.AspNet.Mvc;



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
        public ActionResult CreatePlayer(Player player)
        {
            return CouronneRepository.CreatePlayer(player) == 1
              ? (ActionResult)new HttpOkResult()
              : HttpBadRequest();
            
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