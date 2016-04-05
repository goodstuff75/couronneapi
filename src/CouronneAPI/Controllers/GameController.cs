using System;
using CouronneAPI.Repositories.Interfaces;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CouronneAPI.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        [FromServices]
        public ICouronneRepository CouronneRepository { get; set; }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateGame(int player1, int player2)
        {
            return CouronneRepository.CreateGame(player1, player2) == 1
                ? (ActionResult) new HttpOkResult()
                : HttpBadRequest();
        }

        [HttpPost]
        [Route("setwinner")]
        public ActionResult SetWinner(int player, int gameId)
        {
            return CouronneRepository.SetWinner(player, gameId) == 1
             ? (ActionResult)new HttpOkResult() 
             : HttpBadRequest();
        }
    }
    
}