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
        public string CreateGame(int player1, int player2)
        {
            return string.Format("Game created with id: {0}", CouronneRepository.CreateGame(player1, player2));
        }

        [HttpPost]
        [Route("setwinner")]
        public string SetWinner(int player, int gameId)
        {
            return string.Format("Winner created with id: {0}", CouronneRepository.SetWinner(player, gameId));
        }
    }
}