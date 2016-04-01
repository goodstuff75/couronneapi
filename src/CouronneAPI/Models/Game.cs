using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouronneAPI.Models
{
    public class Game
    {

        public int Id { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int Winner { get; set; }
        public DateTime PlayDate { get; set; }
    }
}
