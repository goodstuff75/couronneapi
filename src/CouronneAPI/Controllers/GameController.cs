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
    public class GameController : Controller
    {
        [FromServices]
        public ICouronneRepository CouronneRepository { get; set; }


        public String Index()
        {
            return "Hello, this is the game Controller";
        }

        [HttpPost]
        public int CreateGame(int player1, int player2)
        {
            return CouronneRepository.CreateGame(player1,player2);
        }
        
        [HttpGet]
        public bool SetWinner(int player, int gameId)
        {
            return CouronneRepository.SetWinner(player, gameId);
        }

   
    }
}
